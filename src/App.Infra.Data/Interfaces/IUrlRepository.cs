namespace App.Infra.Data.Interfaces
{
    public interface IUrlRepository
    {
        Task Inserir(Urls urls);
    }
}