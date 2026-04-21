using AppLogic.UseCase.ItemsCu;
using AppLogic.UseCase.UsersCu;
using AppLogic.UseCase;
using AppLogic.UseCaseInterface.ItemsCU;
using AppLogic.UseCaseInterface.UsersCU;
using AppLogic.UseCaseInterface;
using BussinesLogic.RepositoryInterface;
using LogicDataAccess.ContextEF.Repository;
using AppLogic.UseCase.ClientsCu;
using AppLogic.UseCaseInterface.ClientsCU;
using AppLogic.UseCase.OrdersCu;
using AppLogic.UseCaseInterface.OrdersCU;
using AppLogic.UseCase.MovementTypeCu;
using AppLogic.UseCaseInterface.MovementTypeCU;
using AppLogic.UseCaseInterface.StockMovementCU;
using AppLogic.UseCase.StockMovementCu;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.Filters;
using LogicDataAccess.Context;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<PaperFactoryContext>();

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//User
builder.Services.AddScoped<IRepositoryUser, RepositoryUserEF>();
builder.Services.AddScoped<ICreateUserCU, CreateUserCU>();
builder.Services.AddScoped<IEditUserCU, EditUserCU>();
builder.Services.AddScoped<IDeleteUserCU, DeleteUserCU>();
builder.Services.AddScoped<IFindAllUsersCU, FindAllUsersCU>();
builder.Services.AddScoped<IFindUserByIDCU, FindUserByIDCU>();

//Encriptacion
builder.Services.AddScoped<IEncryptCU, EncryptCU>();
builder.Services.AddScoped<IDecryptCU, DecryptCU>();

//Login
builder.Services.AddScoped<IGetUserByEmailCU, GetUserByEmailCU>();
builder.Services.AddScoped<ILoginCU, LoginCU>();

//Item
builder.Services.AddScoped<IRepositoryItem, RepositoryItemEF>();
builder.Services.AddScoped<IFindAllItemCU, FindAllItemCU>();
builder.Services.AddScoped<ICreateItemCU, CreateItemCU>();
builder.Services.AddScoped<IFindItemByIDCU, FindItemByIDCU>();

//Clientes
builder.Services.AddScoped<IRepositoryClient, RepositoryClientEF>();
builder.Services.AddScoped<IFindAllClientsCU, FindAllClientsCU>();
builder.Services.AddScoped<IFindClientsByNameCU, FindClientsByNameCU>();
builder.Services.AddScoped<IFindClientsBySurenameCU, FindClientsBySurenameCU>();
builder.Services.AddScoped<IFindClientByIDCU, FindClientByIDCU>();
builder.Services.AddScoped<IFindClientsByAmountCU, FindClientsByAmountCU>();

//Pedidos
builder.Services.AddScoped<IRepositoryOrder, RepositoryOrderEF>();
builder.Services.AddScoped<IFindAllOrdersCU, FindAllOrdersCU>();
builder.Services.AddScoped<ICreateOrderCU, CreateOrderCU>();
builder.Services.AddScoped<IFindOrderByIDCU, FindOrderByIDCU>();
builder.Services.AddScoped<ICancelOrderCU, CancelOrderCU>();
builder.Services.AddScoped<IFindCanceledOrdersCU, FindCanceledOrdersCU>();
builder.Services.AddScoped<IFindOrderByDateCU, FindOrderByDateCU>();

//Tipo de movimiento
builder.Services.AddScoped<IRepositoryMovementType, RepositoryMovementTypeEF>();
builder.Services.AddScoped<ICreateMovementTypeCU, CreateMovementTypeCU>();
builder.Services.AddScoped<IEditMovementTypeCU, EditMovementTypeCU>();
builder.Services.AddScoped<IFindAllMovementTypeCU, FindAllMovementTypeCU>();
builder.Services.AddScoped<IDeleteMovementTypeCU, DeleteMovementTypeCU>();
builder.Services.AddScoped<IFindTypeByIDCU, FindTypeByIDCU>();

//Setting
builder.Services.AddScoped<IRepositorySetting, RepositorySettingEF>();

//Movimiento de stock
builder.Services.AddScoped<IRepositoryStockMovement,RepositoryStockMovementEF>();
builder.Services.AddScoped<ICreateStockMovementCU, CreateStockMovementCU >();
builder.Services.AddScoped<IFindAllStockMovementCU, FindAllStockMovementCU>();
builder.Services.AddScoped<IGetItemByDateCU, GetItemByDateCU >();
builder.Services.AddScoped<IGetMovementByItemAndTypeCU, GetMovementByItemAndTypeCU >();

//SUMMARY
builder.Services.AddScoped<ISummaryAmountForYearCU, SummaryAmountForYearCU>();

var ruta = System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "WebApi.xml");
builder.Services.AddSwaggerGen(
        opciones =>
        {
            opciones.AddSecurityDefinition("oauth2", new Microsoft.OpenApi.Models.OpenApiSecurityScheme()
            {
                Description = "Autorización estándar mediante esquema Bearer",
                In = ParameterLocation.Header,
                Name = "Authorization",
                Type = SecuritySchemeType.ApiKey
            });
            opciones.OperationFilter<SecurityRequirementsOperationFilter>();
            opciones.IncludeXmlComments(ruta);
            opciones.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo
            {
                Title = "Papeleria",
                Description = "Gestion de una papeleria.",
                Contact = new Microsoft.OpenApi.Models.OpenApiContact
                {
                    Email = "aguspizzuti2020@gmail.com"
                },
                Version = "v1"
            });
        }
    );


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
