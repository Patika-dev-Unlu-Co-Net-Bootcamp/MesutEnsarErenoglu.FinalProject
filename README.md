# MesutEnsarErenoglu.FinalProject
Unlu&amp;Co .Net Bootcamp Final Project

- Proje solid prensiplere uygun olup içerisinde Clean Architecture, Repository pattern, UnitofWork pattern kullanılarak hazırlanan bir rest api ve ui olarak blazor server application yer almaktadır. 

- Kullancılar projede işlem yapabilmek için üye olmak durumundadır. Kimlik yönetimi jwt token aracılığıyla yapılmaktadır.

- Kullancıların projede yaptığı işlemler akabinde mail gönderimi sağlanmaktadır. İşlem anında rabbit mq kuyruğuna gönderilen email modeli api'de yer alan background service tarafından dinlenmekte ve sırasıyla gönderimleri yapılmaktadır. 

- Kullanıcılar çeşitli kontroller dahilinde bir veya bir den fazla ürün ekleyebilmekte(fotoğraf dahil) ve bu ürünler için teklife açık olup olmadıklarını belirtebilmektedir. 

- Teklife açık olan ürünlere gelen teklifleri güncellebilmekte teklif yapan kullanıcılara yeni teklif ederek pazarlık yapabilmektedir. 

- Teklife kapalı ürünler direk satın alınabilmektedir. 

- Kullancı kendi hesabından sahip olduğu ürünlere, ürünlerine gelen tekliflere, tekliflerin durumlarına, kendi yaptığı başkalarına ait ürünlerin tekliflerine ve durumlarına ulaşabilmektedir. 

- Kategoriler ve bunlara bağlı alt kategoriler yer almaktadır. Ürünler alt kategorilere bağlıdır. Kategori ve alt kategorilerden bağlı ürünlerine ulaşılabilmektedir. 

- Web Api 
- Api projesi altındaki 4 ayrı katmana bağlı olarak çalışmaktadır.
    * FinalProject.Domain katmanında entityler ve repository interfaceler yer almaktadır.
    * FinalProject.Infrastructure katmanında context, migrations, repositories ve unit of work dosyaları yer almaktadır.
    * FinalProject.Common katmanında Background service, email operasyonları, enumlar, validatorlar ve rabbit mq classları yer almaktadır. 
    * FinalProject.Application katmanında Dependency injection container, dtolar, service interfaceleri ve servisler, map profile ve token classları yer almaktadır. 
    *  Controllerlar, modeller ve ürün resimler yer almaktadır. 
    * FinalProject.UI projesi de client side servisler, client side authentication ve sayfalardan oluşmaktadır.

