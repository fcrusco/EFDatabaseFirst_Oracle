//Importa o namespace onde está o AppDbContext.Sem isso, o compilador não “vê” a classe do contexto.
using EFDatabaseFirstOracle.DBContext;

//Cria uma instância do DbContext.
//O using garante o Dispose() automático ao sair do escopo
//Fecha conexão/recursos do EF.
using (var db = new AppDbContext())
{
    //Acessa o DbSet<TB_CLIENTE> (coleção mapeada para a tabela) e executa a consulta no banco
    //Observação: o nome com “s” no fim é normal — o DbSet é uma coleção; o scaffold pluraliza
    //a propriedade (ex.: entidade TB_CLIENTE → DbSet TB_CLIENTEs).
    var clientes = db.TB_CLIENTEs.ToList();

    //Percorre a lista e escreve no console usando interpolação de string.
    //ID_CLIENTE, NOME e SOBRENOME são as propriedades geradas a partir das colunas
    //(normal ficarem em MAIÚSCULAS se usou -UseDatabaseNames no scaffold).
    foreach (var c in clientes)
        Console.WriteLine($"{c.ID_CLIENTE}: {c.NOME} {c.SOBRENOME}");
}