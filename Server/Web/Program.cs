using AppLogic.UseCase;
using AppLogic.UseCase.ClientsCu;
using AppLogic.UseCase.ItemsCu;
using AppLogic.UseCase.MovementTypeCu;
using AppLogic.UseCase.OrdersCu;
using AppLogic.UseCase.StockMovementCu;
using AppLogic.UseCase.UsersCu;
using AppLogic.UseCaseInterface;
using AppLogic.UseCaseInterface.ClientsCU;
using AppLogic.UseCaseInterface.ItemsCU;
using AppLogic.UseCaseInterface.MovementTypeCU;
using AppLogic.UseCaseInterface.OrdersCU;
using AppLogic.UseCaseInterface.StockMovementCU;
using AppLogic.UseCaseInterface.UsersCU;
using BussinesLogic.RepositoryInterface;
using LogicDataAccess.ContextEF.Repository;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

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
builder.Services.AddScoped<IRepositoryMovementType,RepositoryMovementTypeEF>();
builder.Services.AddScoped<ICreateMovementTypeCU, CreateMovementTypeCU>();
builder.Services.AddScoped<IEditMovementTypeCU, EditMovementTypeCU>();
builder.Services.AddScoped<IFindAllMovementTypeCU, FindAllMovementTypeCU>();
builder.Services.AddScoped<IDeleteMovementTypeCU, DeleteMovementTypeCU>();
builder.Services.AddScoped<IFindTypeByIDCU, FindTypeByIDCU>();

//Movimiento de stock
builder.Services.AddScoped<IRepositoryStockMovement, RepositoryStockMovementEF>();
builder.Services.AddScoped<ICreateStockMovementCU, CreateStockMovementCU>();
builder.Services.AddScoped<IFindAllStockMovementCU, FindAllStockMovementCU>();
builder.Services.AddScoped<IGetItemByDateCU, GetItemByDateCU>();
builder.Services.AddScoped<IGetMovementByItemAndTypeCU, GetMovementByItemAndTypeCU>();

//SUMMARY
builder.Services.AddScoped<ISummaryAmountForYearCU, SummaryAmountForYearCU>();

builder.Services.AddSession(options =>
{
    options.IdleTimeout = TimeSpan.FromMinutes(30);
    options.Cookie.HttpOnly = true;
    options.Cookie.IsEssential = true;
});

var app = builder.Build();



// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Login}/{action=Login}/{id?}");

app.UseSession();

app.Run();
