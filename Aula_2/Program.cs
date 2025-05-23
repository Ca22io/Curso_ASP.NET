// Cria um construtor de aplicativo web com os argumentos da linha de comando
var builder = WebApplication.CreateBuilder(args);

// Adiciona os serviços necessários para usar controladores e views (MVC) ao contêiner de injeção de dependência
builder.Services.AddControllersWithViews();

// Constrói o aplicativo web a partir do builder configurado
var app = builder.Build();

// Configura o pipeline de requisições HTTP
if (!app.Environment.IsDevelopment())
{
    // Em ambiente de produção, usa uma página de tratamento de erros customizada
    app.UseExceptionHandler("/Home/Error");
}

// Habilita o uso de arquivos estáticos (como CSS, JS, imagens) na aplicação
app.UseStaticFiles();

// Adiciona o roteamento ao pipeline, permitindo mapear URLs para controladores/actions
app.UseRouting();

// Adiciona a autorização ao pipeline (verifica se o usuário tem permissão para acessar recursos)
app.UseAuthorization();

// Define a rota padrão para o MVC: controller=Home, action=Index, id é opcional
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

// Inicia o aplicativo e começa a escutar requisições HTTP
app.Run();
