using Client.Common.Data;

namespace Client.Common.Services.StaticDataProvider
{
    //дать ему возможность кешировать данные при загрузке.
    //при загрузке всех ассетов, оповещаются обработчики.
    //провайдер данных как раз и есть такой обработчик.
    //он проверяет данные и складывает их в словарь
    //потом он отдаёт данные по запросу.
    //таким образом ресурсы буду загружены фактически 1 раз
    
    public class StaticDataProvider : IStaticDataProvider, IAssetReceiver
    {
        public void Initialize(ProjectConfig projectConfig) => Project = projectConfig;

        public ProjectConfig Project { get; private set; }
        
        public void Receive(object asset)
        {
            //как получать загруженные ассеты ? 
            //может ли, например фабрика получать ассеты для последующего создания объектов ?
            //провайдер конфигов выглядит как хорошая вещь.
        }
    }

    public interface IAssetReceiver
    {
        void Receive(object asset);
    }
}