using AppLogic.DTOs;
using BussinesLogic.Entity;
using BussinesLogic.Exceptions.OrderException;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppLogic.MapperDTO
{
    public class OrderDTOMapper
    {

        public static OrderDTO ToDto(Order order) 
        {
            order.lines.Select(line => LineDTOMapper.ToDto(line));
            ClientDTOMapper.ToDto(order.client);
            return new OrderDTO(order);
        }

        public static Order FromDto(OrderDTO orderDto) 
        {
            if (orderDto == null)
            {
                throw new OrderException("");
            }

            if (orderDto.isExrpress)
            {
                return new Express(orderDto.Id, orderDto.creationDate, orderDto.deliveryDate, orderDto.idClient,
                    ClientDTOMapper.FromDto(orderDto.client), orderDto.lines.Select(line => LineDTOMapper.FromDto(line)).ToList(),
                    orderDto.cancel, orderDto.delivered, orderDto.finalPrice, orderDto.isExrpress);
            }
            else
            {
                return new Comun(orderDto.Id, orderDto.creationDate, orderDto.deliveryDate, orderDto.idClient, 
                    ClientDTOMapper.FromDto(orderDto.client), orderDto.lines.Select(line => LineDTOMapper.FromDto(line)).ToList(), 
                    orderDto.cancel, orderDto.delivered, orderDto.finalPrice, orderDto.isExrpress);
            }

        }


    }
}
