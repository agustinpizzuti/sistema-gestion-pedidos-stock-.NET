using BussinesLogic.Entity;
using BussinesLogic.Exceptions.UserException;
using BussinesLogic.RepositoryInterface;
using LogicDataAccess.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Buffers.Text;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.Intrinsics.Arm;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using Aes = System.Security.Cryptography.Aes;

namespace LogicDataAccess.ContextEF.Repository
{
    public class RepositoryUserEF : IRepositoryUser
    {
        private const string EncryptionKey = "G#2!3tB8N*q6@W#Y";

        private PaperFactoryContext _context;

        public RepositoryUserEF() 
        {
            _context = new PaperFactoryContext();
        }

        public bool Add(User userToAdd)
        {
            try
            {
                User user = this.FindByMail(userToAdd.mail);

                if (user == null)
                {
                    userToAdd.IsValidWithSettings(new RepositorySettingEF());
                    _context.Add(userToAdd);
                    _context.SaveChanges();
                    return true;
                }
                else 
                {
                    throw new UserException("El mail ingresado ya existe");
                }        
            }
            catch (UserException ex)
            {
                throw ex;
            }
        }

        public string Decrypt(string passEncrip)
        {
            try 
            {
                //se decodifica la contraseña y se guarda en un arreglo de bytes
                byte[] cipherTextBytes = Convert.FromBase64String(passEncrip);

                string decryptedText;

                //se crea una instancia de Aes
                using (Aes aesAlg = Aes.Create())
                {
                    //se le asigna la clave q definimos
                    aesAlg.Key = Encoding.UTF8.GetBytes(EncryptionKey);

                    aesAlg.IV = aesAlg.Key.Take(16).ToArray(); // Utilizamos los primeros 16 bytes de la clave como IV (Initialization Vector)

                    //se encarga de realizar la transfomracion de cifrado
                    ICryptoTransform decryptor = aesAlg.CreateDecryptor(aesAlg.Key, aesAlg.IV);

                    //se crea un flujo de memoria que guarda los datos descifrados
                    using (MemoryStream msDecrypt = new MemoryStream(cipherTextBytes))
                    {
                        //se crea una flujo de descifrado q utiliza el flujo de memoria y la transformacion de cifrado
                        using (CryptoStream csDecrypt = new CryptoStream(msDecrypt, decryptor, CryptoStreamMode.Read))
                        {
                            //se crea una flujo de lectura q se encarga de leer los datos descifrados del flujo de descifrado
                            using (StreamReader srDecrypt = new StreamReader(csDecrypt))
                            {
                                //se leen los datos y se guardan
                                decryptedText = srDecrypt.ReadToEnd();
                            }
                        }
                    }
                }
                
                return decryptedText;
            }
            catch(UserException ex) 
            {
                throw ex;
            }
           
        }

        public string Encrypt(string pass)
        {
            try 
            {
                //arreglo para almacenar los datos ya cifrados
                byte[] encryptedBytes;

                //se crea una instancia de Aes q es un algoritmo de cifrado
                using (Aes aesAlg = Aes.Create())
                {
                    //se le da la clave q definimos
                    aesAlg.Key = Encoding.UTF8.GetBytes(EncryptionKey);

                    aesAlg.IV = aesAlg.Key.Take(16).ToArray(); // Utilizamos los primeros 16 bytes de la clave como IV (Initialization Vector)

                    //se crea una instancia de ICrypto que se encarga de realizar la transformacion de cifrado
                    ICryptoTransform encryptor = aesAlg.CreateEncryptor(aesAlg.Key, aesAlg.IV);

                    //se crea un flujo de memoria que va a almacenar los datos cifrados para no guardar el dato 
                    using (MemoryStream msEncrypt = new MemoryStream())
                    {
                        //se crea un flujo de cifrado que utiliza el flujo de memoria y la transformacion de cifrado, se guarda solo cifrada 
                        using (CryptoStream csEncrypt = new CryptoStream(msEncrypt, encryptor, CryptoStreamMode.Write))
                        {
                            //se crea una instancia de escritor de flujo que se va a encargar de escribir la contraseña en el flujo de cifrado
                            using (StreamWriter swEncrypt = new StreamWriter(csEncrypt))
                            {
                                //se escribe la contraseña en el flujo de cifrado
                                swEncrypt.Write(pass);
                            }

                            //una vez los datos cifrados lo convertimos al arreglo de bytes
                            encryptedBytes = msEncrypt.ToArray();
                        }
                    }
                }

                //devolvemos los datos cifrados
                return Convert.ToBase64String(encryptedBytes);
            } 
            catch (UserException ex) 
            { 
                throw ex; 
            }
            
        }

        public IEnumerable<User> FindAll()
        {
            return _context.users.ToList();
        }

        public User FindByID(int id)
        {
            return _context.users.Where(user => user.Id == id).FirstOrDefault();
        }

        public User FindByMail(string mail)
        {
            try 
            {
                return _context.users.Where(user => user.mail == mail).FirstOrDefault();
            }
            catch (UserException ex) 
            {
                throw ex;
            }
                       
        }  

        //verficar q funq
        public bool Remove(int id)
        {
            try 
            {
                User user = FindByID(id);
                _context.users.Remove(user);
                _context.SaveChanges();
                return true;
            } 
            catch(UserException ex)
            {
                throw ex;
            }
        }

        public bool Update(User userToUpdate)
        {
            try 
            {
                userToUpdate.IsValidWithSettings(new RepositorySettingEF());
                _context.users.Update(userToUpdate);
                _context.SaveChanges();
                return true;
            } 
            
            catch (UserException ex)
            {
                throw ex;
            }
        }
    }
}
