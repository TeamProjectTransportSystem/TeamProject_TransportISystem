using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TransportInfoService.DatabaseClasses
{
    public class TransportDBseeder : CreateDatabaseIfNotExists<TransportDBContext>
    {
        protected override void Seed(TransportDBContext context)
        {
            //дни курсирования
            DayOfCruising monday = new DayOfCruising("Понедельник");
            DayOfCruising tuesday = new DayOfCruising("Вторник");
            DayOfCruising wednesday = new DayOfCruising("Среда");
            DayOfCruising thursday = new DayOfCruising("Четверг");
            DayOfCruising friday = new DayOfCruising("Пятница");
            DayOfCruising saturday = new DayOfCruising("Суббота");
            DayOfCruising sunday = new DayOfCruising("Воскресенье");
            DayOfCruising daily = new DayOfCruising("Ежедневно");

            //тип станций
            StationType station = new StationType("Станция");
            StationType op = new StationType("ОП");

            Station minsk_pass = new Station("Минск-Пассажирский", 0, station);

            //станции на Борисов
            Station minsk_ost = new Station("Минск-Восточный", 3, station);
            Station tractor = new Station("Тракторный", 6, op);
            Station stepyanka = new Station("Степянка", 9, station);
            Station ozerische = new Station("Озерище", 13, station);
            Station kolodischy = new Station("Колодищи", 17, station);
            Station sadovy = new Station("Садовый", 21, op);
            Station gorodische = new Station("Городище", 24, station);
            Station sloboda = new Station("Слобода", 28, op);
            Station domashany = new Station("Домашаны", 31, op);
            Station zogorie = new Station("Загорье", 35, op);
            Station smolevichi = new Station("Смолевичи", 39, station);
            Station zarechnoe = new Station("Заречное", 42, op);
            Station krasnoe_znamya = new Station("Красное знамя", 49, station);
            Station barsuki = new Station("Барсуки", 56, op);
            Station jodino_yujnoe = new Station("Жодино-Южное", 58, op);
            Station jodino = new Station("Жодино", 61, station);
            Station proletarskaya_pobeda = new Station("Пролетарская победа", 66, op);
            Station pechinski = new Station("Печинский", 73, op);
            Station borisov = new Station("Борисов", 80, station);

            //станции на Молодечно
            Station minsk_severny = new Station("Минск-Северный", 3, op);
            Station masyukovschina = new Station("Масюковщина", 7, op);
            Station lebyaji = new Station("Лебяжий", 9, op);
            Station jdanovichy = new Station("Ждановичи", 11, station);
            Station minskoe_more = new Station("Минское море", 14, op);
            Station ratomka = new Station("Ратомка", 16, station);
            Station kryjovka = new Station("Крыжовка", 19, op);
            Station zelenoe = new Station("Зеленое", 23, op);
            Station belarus = new Station("Беларусь", 26, station);
            Station hmelevka = new Station("Хмелевка", 28, op);
            Station anusino = new Station("Анусино", 32, op);
            Station radoshkovichy = new Station("Радошковичи", 34, station);
            Station vjazynka = new Station("Вязынка", 37, op);
            Station pralesky = new Station("Пралески", 40, op);
            Station dubravy = new Station("Дубравы", 41, station);
            Station romany = new Station("Романы", 44, op);
            Station olehnovichi = new Station("Олехновичи", 47, station);
            Station boyary = new Station("Бояры", 52, op);
            Station losy = new Station("Лоси", 55, op);
            Station usha = new Station("Уша", 60, station);
            Station myasota = new Station("Мясота", 64, op);
            Station tatarschizna = new Station("Татарщизна", 67, op);
            Station krynica = new Station("Крыница", 69, op);
            Station selivonovka = new Station("Селивоновка", 71, op);
            Station festivalny = new Station("Фестивальный", 73, op);
            Station molodechno = new Station("Молодечно", 77, station);

            //станции на Столбцы
            Station stolichny = new Station("Столичный", 3, op);
            Station kurasovschina = new Station("Курасовщина", 7, op);
            Station roscha = new Station("Роща", 9, op);
            Station pomyslische = new Station("Помыслище", 11, station);
            Station ptich = new Station("Птичь", 16, op);
            Station volchkovichi = new Station("Волчковичи", 19, op);
            Station fanipol = new Station("Фаниполь", 23, station);
            Station bereja = new Station("Бежа", 29, op);
            Station pyatigorie = new Station("Пятигорье", 32, op);
            Station stankovo = new Station("Станьково", 34, op);
            Station koydanovo = new Station("Койданово", 38, station);
            Station dzerjinsk = new Station("Дзержинск", 40, op);
            Station klypovschina = new Station("Клыповщина", 45, op);
            Station negoreloe = new Station("Негорелое", 50, station);
            Station energetik = new Station("Энергетик", 52, op);
            Station asino = new Station("Асино", 56, op);
            Station mezinovka = new Station("Мезиновка", 60, op);
            Station kolosovo = new Station("Колосово", 63, station);
            Station otceda = new Station("Отцеда", 67, op);
            Station kuchkuny = new Station("Кучкуны", 70, op);
            Station temnye_lyady = new Station("Темные ляды", 73, op);
            Station stolbcy = new Station("Столбцы", 76, station);

            //станции на Пуховичи
            Station minsk_yujny = new Station("Минск-Южный", 3, station);
            Station loshitca = new Station("Лошица", 5, op);
            Station jeleznodorojny = new Station("Железнодорожный", 8, op);
            Station kolyadichi = new Station("Колядичи", 10, station);
            Station machulischi = new Station("Мачулищи", 13, op);
            Station aseevka = new Station("Асеевка", 17, op);
            Station mihanovichi = new Station("Михановичи", 20, station);
            Station sedcha = new Station("Седча", 29, op);
            Station zazerka = new Station("Зазерка", 32, op);
            Station rybcy = new Station("Рыбцы", 34, op);
            Station ravnopolie = new Station("Равнополье", 37, op);
            Station rudensk = new Station("Руденск", 41, station);
            Station novoe_selo = new Station("Новое село", 47, op);
            Station drichin = new Station("Дричин", 52, op);
            Station vendej = new Station("Вендеж", 56, op);
            Station tehnikum = new Station("Техникум", 60, op);
            Station puhovichi = new Station("Пуховичи", 63, station);

            //маршрут Минск-Борисов
            Route routeMinskBorisov = new Route("Минск-Борисов");
            routeMinskBorisov.ListOfStations.Add(minsk_pass);
            routeMinskBorisov.ListOfStations.Add(minsk_ost);
            routeMinskBorisov.ListOfStations.Add(tractor);
            routeMinskBorisov.ListOfStations.Add(stepyanka);
            routeMinskBorisov.ListOfStations.Add(ozerische);
            routeMinskBorisov.ListOfStations.Add(kolodischy);
            routeMinskBorisov.ListOfStations.Add(sadovy);
            routeMinskBorisov.ListOfStations.Add(gorodische);
            routeMinskBorisov.ListOfStations.Add(sloboda);
            routeMinskBorisov.ListOfStations.Add(domashany);
            routeMinskBorisov.ListOfStations.Add(zogorie);
            routeMinskBorisov.ListOfStations.Add(smolevichi);
            routeMinskBorisov.ListOfStations.Add(zarechnoe);
            routeMinskBorisov.ListOfStations.Add(krasnoe_znamya);
            routeMinskBorisov.ListOfStations.Add(barsuki);
            routeMinskBorisov.ListOfStations.Add(jodino_yujnoe);
            routeMinskBorisov.ListOfStations.Add(jodino);
            routeMinskBorisov.ListOfStations.Add(proletarskaya_pobeda);
            routeMinskBorisov.ListOfStations.Add(pechinski);
            routeMinskBorisov.ListOfStations.Add(borisov);

            //маршрут Минск-Молодечно
            Route routeMinskMolodechno = new Route("Минск-Молодечно");
            routeMinskMolodechno.ListOfStations.Add(minsk_pass);
            routeMinskMolodechno.ListOfStations.Add(minsk_severny);
            routeMinskMolodechno.ListOfStations.Add(masyukovschina);
            routeMinskMolodechno.ListOfStations.Add(lebyaji);
            routeMinskMolodechno.ListOfStations.Add(jdanovichy);
            routeMinskMolodechno.ListOfStations.Add(minskoe_more);
            routeMinskMolodechno.ListOfStations.Add(ratomka);
            routeMinskMolodechno.ListOfStations.Add(kryjovka);
            routeMinskMolodechno.ListOfStations.Add(zelenoe);
            routeMinskMolodechno.ListOfStations.Add(belarus);
            routeMinskMolodechno.ListOfStations.Add(hmelevka);
            routeMinskMolodechno.ListOfStations.Add(anusino);
            routeMinskMolodechno.ListOfStations.Add(radoshkovichy);
            routeMinskMolodechno.ListOfStations.Add(vjazynka);
            routeMinskMolodechno.ListOfStations.Add(pralesky);
            routeMinskMolodechno.ListOfStations.Add(dubravy);
            routeMinskMolodechno.ListOfStations.Add(romany);
            routeMinskMolodechno.ListOfStations.Add(olehnovichi);
            routeMinskMolodechno.ListOfStations.Add(boyary);
            routeMinskMolodechno.ListOfStations.Add(losy);
            routeMinskMolodechno.ListOfStations.Add(usha);
            routeMinskMolodechno.ListOfStations.Add(myasota);
            routeMinskMolodechno.ListOfStations.Add(tatarschizna);
            routeMinskMolodechno.ListOfStations.Add(krynica);
            routeMinskMolodechno.ListOfStations.Add(selivonovka);
            routeMinskMolodechno.ListOfStations.Add(festivalny);
            routeMinskMolodechno.ListOfStations.Add(molodechno);

            //маршрут Минск-Столбцы
            Route routeMinskStolbcy = new Route("Минск-Столбцы");
            routeMinskStolbcy.ListOfStations.Add(minsk_pass);
            routeMinskStolbcy.ListOfStations.Add(stolichny);
            routeMinskStolbcy.ListOfStations.Add(kurasovschina);
            routeMinskStolbcy.ListOfStations.Add(roscha);
            routeMinskStolbcy.ListOfStations.Add(pomyslische);
            routeMinskStolbcy.ListOfStations.Add(ptich);
            routeMinskStolbcy.ListOfStations.Add(volchkovichi);
            routeMinskStolbcy.ListOfStations.Add(fanipol);
            routeMinskStolbcy.ListOfStations.Add(bereja);
            routeMinskStolbcy.ListOfStations.Add(pyatigorie);
            routeMinskStolbcy.ListOfStations.Add(stankovo);
            routeMinskStolbcy.ListOfStations.Add(koydanovo);
            routeMinskStolbcy.ListOfStations.Add(dzerjinsk);
            routeMinskStolbcy.ListOfStations.Add(klypovschina);
            routeMinskStolbcy.ListOfStations.Add(negoreloe);
            routeMinskStolbcy.ListOfStations.Add(energetik);
            routeMinskStolbcy.ListOfStations.Add(asino);
            routeMinskStolbcy.ListOfStations.Add(mezinovka);
            routeMinskStolbcy.ListOfStations.Add(kolosovo);
            routeMinskStolbcy.ListOfStations.Add(otceda);
            routeMinskStolbcy.ListOfStations.Add(kuchkuny);
            routeMinskStolbcy.ListOfStations.Add(temnye_lyady);
            routeMinskStolbcy.ListOfStations.Add(stolbcy);

            //маршрут Минск-Пуховичи
            Route routeMinskPuhovichi = new Route("Минск-Пуховичи");
            routeMinskPuhovichi.ListOfStations.Add(minsk_pass);
            routeMinskPuhovichi.ListOfStations.Add(minsk_yujny);
            routeMinskPuhovichi.ListOfStations.Add(loshitca);
            routeMinskPuhovichi.ListOfStations.Add(jeleznodorojny);
            routeMinskPuhovichi.ListOfStations.Add(kolyadichi);
            routeMinskPuhovichi.ListOfStations.Add(machulischi);
            routeMinskPuhovichi.ListOfStations.Add(aseevka);
            routeMinskPuhovichi.ListOfStations.Add(mihanovichi);
            routeMinskPuhovichi.ListOfStations.Add(sedcha);
            routeMinskPuhovichi.ListOfStations.Add(zazerka);
            routeMinskPuhovichi.ListOfStations.Add(rybcy);
            routeMinskPuhovichi.ListOfStations.Add(ravnopolie);
            routeMinskPuhovichi.ListOfStations.Add(rudensk);
            routeMinskPuhovichi.ListOfStations.Add(novoe_selo);
            routeMinskPuhovichi.ListOfStations.Add(drichin);
            routeMinskPuhovichi.ListOfStations.Add(vendej);
            routeMinskPuhovichi.ListOfStations.Add(tehnikum);
            routeMinskPuhovichi.ListOfStations.Add(puhovichi);

            //типы поездов
            TrainType econom = new TrainType("Эконом", 700, 50);
            TrainType business = new TrainType("Бизнес", 1000, 70);
            TrainType fast = new TrainType("Скорый", 1500, 100);

            //первый поезд на Борисов
            Train trainBorisov1 = new Train("061B", econom, routeMinskBorisov);
            trainBorisov1.ListOfDepartureTimeAndDaysOfCruising.Add(new DepartureTimeAndDayOfCruising(7, 00, true, new List<DayOfCruising>() {saturday, sunday}));

            trainBorisov1.ListOfDepartureTimeAndDaysOfCruising.Add(new DepartureTimeAndDayOfCruising(11, 20, true, new List<DayOfCruising>() {daily}));
            trainBorisov1.ListOfDepartureTimeAndDaysOfCruising.Add(new DepartureTimeAndDayOfCruising(16, 40, true, new List<DayOfCruising>() { daily }));
            trainBorisov1.ListOfDepartureTimeAndDaysOfCruising.Add(new DepartureTimeAndDayOfCruising(19, 30, true, new List<DayOfCruising>() { saturday, sunday }));
            trainBorisov1.ListOfDepartureTimeAndDaysOfCruising.Add(new DepartureTimeAndDayOfCruising(22, 50, true, new List<DayOfCruising>() {daily}));

            //второй поезд на Борисов
            Train trainBorisov2 = new Train("095A", econom, routeMinskBorisov);
            trainBorisov2.ListOfDepartureTimeAndDaysOfCruising.Add(new DepartureTimeAndDayOfCruising(7, 30, true, new List<DayOfCruising>() { saturday, sunday }));
            trainBorisov2.ListOfDepartureTimeAndDaysOfCruising.Add(new DepartureTimeAndDayOfCruising(11, 40, true, new List<DayOfCruising>() { daily }));
            trainBorisov2.ListOfDepartureTimeAndDaysOfCruising.Add(new DepartureTimeAndDayOfCruising(17, 00, true, new List<DayOfCruising>() { daily }));
            trainBorisov2.ListOfDepartureTimeAndDaysOfCruising.Add(new DepartureTimeAndDayOfCruising(19, 50, true, new List<DayOfCruising>() { saturday, sunday }));
            trainBorisov2.ListOfDepartureTimeAndDaysOfCruising.Add(new DepartureTimeAndDayOfCruising(23, 10, true, new List<DayOfCruising>() { daily }));

            //третий поезд на Борисов
            Train trainBorisov3 = new Train("086С", econom, routeMinskBorisov);
            trainBorisov3.ListOfDepartureTimeAndDaysOfCruising.Add(new DepartureTimeAndDayOfCruising(7, 50, true, new List<DayOfCruising>() { saturday, sunday }));
            trainBorisov3.ListOfDepartureTimeAndDaysOfCruising.Add(new DepartureTimeAndDayOfCruising(12, 00, true, new List<DayOfCruising>() { daily }));
            trainBorisov3.ListOfDepartureTimeAndDaysOfCruising.Add(new DepartureTimeAndDayOfCruising(17, 30, true, new List<DayOfCruising>() { daily }));
            trainBorisov3.ListOfDepartureTimeAndDaysOfCruising.Add(new DepartureTimeAndDayOfCruising(20, 20, true, new List<DayOfCruising>() { saturday, sunday }));
            trainBorisov3.ListOfDepartureTimeAndDaysOfCruising.Add(new DepartureTimeAndDayOfCruising(23, 30, true, new List<DayOfCruising>() { daily }));

            //первый поезд на Молодечно
            Train trainMolodechno1 = new Train("136A", econom, routeMinskMolodechno);
            trainMolodechno1.ListOfDepartureTimeAndDaysOfCruising.Add(new DepartureTimeAndDayOfCruising(7, 10, true, new List<DayOfCruising>() { saturday, sunday }));
            trainMolodechno1.ListOfDepartureTimeAndDaysOfCruising.Add(new DepartureTimeAndDayOfCruising(11, 40, true, new List<DayOfCruising>() { daily }));
            trainMolodechno1.ListOfDepartureTimeAndDaysOfCruising.Add(new DepartureTimeAndDayOfCruising(16, 50, true, new List<DayOfCruising>() { daily }));
            trainMolodechno1.ListOfDepartureTimeAndDaysOfCruising.Add(new DepartureTimeAndDayOfCruising(19, 00, true, new List<DayOfCruising>() { saturday, sunday }));
            trainMolodechno1.ListOfDepartureTimeAndDaysOfCruising.Add(new DepartureTimeAndDayOfCruising(22, 10, true, new List<DayOfCruising>() { daily }));

            //второй поезд на Молодечно
            Train trainMolodechno2 = new Train("152B", econom, routeMinskMolodechno);
            trainMolodechno2.ListOfDepartureTimeAndDaysOfCruising.Add(new DepartureTimeAndDayOfCruising(7, 40, true, new List<DayOfCruising>() { saturday, sunday }));
            trainMolodechno2.ListOfDepartureTimeAndDaysOfCruising.Add(new DepartureTimeAndDayOfCruising(12, 10, true, new List<DayOfCruising>() { daily }));
            trainMolodechno2.ListOfDepartureTimeAndDaysOfCruising.Add(new DepartureTimeAndDayOfCruising(17, 20, true, new List<DayOfCruising>() { daily }));
            trainMolodechno2.ListOfDepartureTimeAndDaysOfCruising.Add(new DepartureTimeAndDayOfCruising(19, 30, true, new List<DayOfCruising>() { saturday, sunday }));
            trainMolodechno2.ListOfDepartureTimeAndDaysOfCruising.Add(new DepartureTimeAndDayOfCruising(22, 40, true, new List<DayOfCruising>() { daily }));

            //третий поезд на Молодечно
            Train trainMolodechno3 = new Train("174С", econom, routeMinskMolodechno);
            trainMolodechno3.ListOfDepartureTimeAndDaysOfCruising.Add(new DepartureTimeAndDayOfCruising(7, 40, true, new List<DayOfCruising>() { saturday, sunday }));
            trainMolodechno3.ListOfDepartureTimeAndDaysOfCruising.Add(new DepartureTimeAndDayOfCruising(12, 10, true, new List<DayOfCruising>() { daily }));
            trainMolodechno3.ListOfDepartureTimeAndDaysOfCruising.Add(new DepartureTimeAndDayOfCruising(17, 20, true, new List<DayOfCruising>() { daily }));
            trainMolodechno3.ListOfDepartureTimeAndDaysOfCruising.Add(new DepartureTimeAndDayOfCruising(19, 30, true, new List<DayOfCruising>() { saturday, sunday }));
            trainMolodechno3.ListOfDepartureTimeAndDaysOfCruising.Add(new DepartureTimeAndDayOfCruising(22, 40, true, new List<DayOfCruising>() { daily }));

            //первый поезд на Столбцы
            Train trainStolbcy1 = new Train("261B", econom, routeMinskStolbcy);
            trainStolbcy1.ListOfDepartureTimeAndDaysOfCruising.Add(new DepartureTimeAndDayOfCruising(7, 00, true, new List<DayOfCruising>() { saturday, sunday }));
            trainStolbcy1.ListOfDepartureTimeAndDaysOfCruising.Add(new DepartureTimeAndDayOfCruising(11, 20, true, new List<DayOfCruising>() { daily }));
            trainStolbcy1.ListOfDepartureTimeAndDaysOfCruising.Add(new DepartureTimeAndDayOfCruising(16, 40, true, new List<DayOfCruising>() { daily }));
            trainStolbcy1.ListOfDepartureTimeAndDaysOfCruising.Add(new DepartureTimeAndDayOfCruising(19, 30, true, new List<DayOfCruising>() { saturday, sunday }));
            trainStolbcy1.ListOfDepartureTimeAndDaysOfCruising.Add(new DepartureTimeAndDayOfCruising(22, 50, true, new List<DayOfCruising>() { daily }));

            //второй поезд на Столбцы
            Train trainStolbcy2 = new Train("295A", econom, routeMinskStolbcy);
            trainStolbcy2.ListOfDepartureTimeAndDaysOfCruising.Add(new DepartureTimeAndDayOfCruising(7, 30, true, new List<DayOfCruising>() { saturday, sunday }));
            trainStolbcy2.ListOfDepartureTimeAndDaysOfCruising.Add(new DepartureTimeAndDayOfCruising(11, 40, true, new List<DayOfCruising>() { daily }));
            trainStolbcy2.ListOfDepartureTimeAndDaysOfCruising.Add(new DepartureTimeAndDayOfCruising(17, 00, true, new List<DayOfCruising>() { daily }));
            trainStolbcy2.ListOfDepartureTimeAndDaysOfCruising.Add(new DepartureTimeAndDayOfCruising(19, 50, true, new List<DayOfCruising>() { saturday, sunday }));
            trainStolbcy2.ListOfDepartureTimeAndDaysOfCruising.Add(new DepartureTimeAndDayOfCruising(23, 10, true, new List<DayOfCruising>() { daily }));

            //третий поезд на Столбцы
            Train trainStolbcy3 = new Train("286С", econom, routeMinskStolbcy);
            trainStolbcy3.ListOfDepartureTimeAndDaysOfCruising.Add(new DepartureTimeAndDayOfCruising(7, 50, true, new List<DayOfCruising>() { saturday, sunday }));
            trainStolbcy3.ListOfDepartureTimeAndDaysOfCruising.Add(new DepartureTimeAndDayOfCruising(12, 00, true, new List<DayOfCruising>() { daily }));
            trainStolbcy3.ListOfDepartureTimeAndDaysOfCruising.Add(new DepartureTimeAndDayOfCruising(17, 30, true, new List<DayOfCruising>() { daily }));
            trainStolbcy3.ListOfDepartureTimeAndDaysOfCruising.Add(new DepartureTimeAndDayOfCruising(20, 20, true, new List<DayOfCruising>() { saturday, sunday }));
            trainStolbcy3.ListOfDepartureTimeAndDaysOfCruising.Add(new DepartureTimeAndDayOfCruising(23, 30, true, new List<DayOfCruising>() { daily }));

            //первый поезд на Пуховичи
            Train trainPuhovichi1 = new Train("335A", econom, routeMinskPuhovichi);
            trainPuhovichi1.ListOfDepartureTimeAndDaysOfCruising.Add(new DepartureTimeAndDayOfCruising(6, 50, true, new List<DayOfCruising>() { saturday, sunday }));
            trainPuhovichi1.ListOfDepartureTimeAndDaysOfCruising.Add(new DepartureTimeAndDayOfCruising(10, 40, true, new List<DayOfCruising>() { daily }));
            trainPuhovichi1.ListOfDepartureTimeAndDaysOfCruising.Add(new DepartureTimeAndDayOfCruising(16, 30, true, new List<DayOfCruising>() { daily }));
            trainPuhovichi1.ListOfDepartureTimeAndDaysOfCruising.Add(new DepartureTimeAndDayOfCruising(18, 20, true, new List<DayOfCruising>() { saturday, sunday }));
            trainPuhovichi1.ListOfDepartureTimeAndDaysOfCruising.Add(new DepartureTimeAndDayOfCruising(20, 10, true, new List<DayOfCruising>() { daily }));
            trainPuhovichi1.ListOfDepartureTimeAndDaysOfCruising.Add(new DepartureTimeAndDayOfCruising(21, 00, true, new List<DayOfCruising>() { daily }));

            //второй поезд на Пуховичи
            Train trainPuhovichi2 = new Train("358B", econom, routeMinskPuhovichi);
            trainPuhovichi2.ListOfDepartureTimeAndDaysOfCruising.Add(new DepartureTimeAndDayOfCruising(6, 50, true, new List<DayOfCruising>() { saturday, sunday }));
            trainPuhovichi2.ListOfDepartureTimeAndDaysOfCruising.Add(new DepartureTimeAndDayOfCruising(10, 40, true, new List<DayOfCruising>() { daily }));
            trainPuhovichi2.ListOfDepartureTimeAndDaysOfCruising.Add(new DepartureTimeAndDayOfCruising(16, 30, true, new List<DayOfCruising>() { daily }));
            trainPuhovichi2.ListOfDepartureTimeAndDaysOfCruising.Add(new DepartureTimeAndDayOfCruising(18, 20, true, new List<DayOfCruising>() { saturday, sunday }));
            trainPuhovichi2.ListOfDepartureTimeAndDaysOfCruising.Add(new DepartureTimeAndDayOfCruising(20, 10, true, new List<DayOfCruising>() { daily }));
            trainPuhovichi2.ListOfDepartureTimeAndDaysOfCruising.Add(new DepartureTimeAndDayOfCruising(21, 00, true, new List<DayOfCruising>() { daily }));

            //третий поезд на Пуховичи
            Train trainPuhovichi3 = new Train("377С", econom, routeMinskPuhovichi);
            trainPuhovichi3.ListOfDepartureTimeAndDaysOfCruising.Add(new DepartureTimeAndDayOfCruising(6, 50, true, new List<DayOfCruising>() { saturday, sunday }));
            trainPuhovichi3.ListOfDepartureTimeAndDaysOfCruising.Add(new DepartureTimeAndDayOfCruising(10, 40, true, new List<DayOfCruising>() { daily }));
            trainPuhovichi3.ListOfDepartureTimeAndDaysOfCruising.Add(new DepartureTimeAndDayOfCruising(16, 30, true, new List<DayOfCruising>() { daily }));
            trainPuhovichi3.ListOfDepartureTimeAndDaysOfCruising.Add(new DepartureTimeAndDayOfCruising(18, 20, true, new List<DayOfCruising>() { saturday, sunday }));
            trainPuhovichi3.ListOfDepartureTimeAndDaysOfCruising.Add(new DepartureTimeAndDayOfCruising(20, 10, true, new List<DayOfCruising>() { daily }));
            trainPuhovichi3.ListOfDepartureTimeAndDaysOfCruising.Add(new DepartureTimeAndDayOfCruising(21, 00, true, new List<DayOfCruising>() { daily }));

            routeMinskBorisov.ListOfTrains.Add(trainBorisov1);
            routeMinskBorisov.ListOfTrains.Add(trainBorisov2);
            routeMinskBorisov.ListOfTrains.Add(trainBorisov3);

            routeMinskMolodechno.ListOfTrains.Add(trainMolodechno1);
            routeMinskMolodechno.ListOfTrains.Add(trainMolodechno2);
            routeMinskMolodechno.ListOfTrains.Add(trainMolodechno3);

            routeMinskPuhovichi.ListOfTrains.Add(trainPuhovichi1);
            routeMinskPuhovichi.ListOfTrains.Add(trainPuhovichi2);
            routeMinskPuhovichi.ListOfTrains.Add(trainPuhovichi3);

            routeMinskStolbcy.ListOfTrains.Add(trainStolbcy1);
            routeMinskStolbcy.ListOfTrains.Add(trainStolbcy2);
            routeMinskStolbcy.ListOfTrains.Add(trainStolbcy3);


            WagonType sedentaryWagonForTrainEconom = new WagonType("Сидячий Эконом", 200, false);
            WagonSector sedentaryWagonEconom = new WagonSector(sedentaryWagonForTrainEconom, 1, 5);
            SeatSector seatSectorSedentaryWagonEconom = new SeatSector(1, 91, false);

            for (int i = 0; i < 10; ++i)
                trainBorisov1.Wagons.Add(sedentaryWagonEconom);
                
            for (int i = 0; i < 10; ++i)
                trainBorisov2.Wagons.Add(sedentaryWagonEconom);

            for (int i = 0; i < 10; ++i)
                trainBorisov3.Wagons.Add(sedentaryWagonEconom);

            for (int i = 0; i < 10; ++i)
                trainMolodechno1.Wagons.Add(sedentaryWagonEconom);

            for (int i = 0; i < 10; ++i)
                trainMolodechno2.Wagons.Add(sedentaryWagonEconom);

            for (int i = 0; i < 10; ++i)
                trainMolodechno3.Wagons.Add(sedentaryWagonEconom);

            for (int i = 0; i < 10; ++i)
                trainPuhovichi1.Wagons.Add(sedentaryWagonEconom);

            for (int i = 0; i < 10; ++i)
                trainPuhovichi2.Wagons.Add(sedentaryWagonEconom);

            for (int i = 0; i < 10; ++i)
                trainPuhovichi3.Wagons.Add(sedentaryWagonEconom);

            for (int i = 0; i < 10; ++i)
                trainStolbcy1.Wagons.Add(sedentaryWagonEconom);

            for (int i = 0; i < 10; ++i)
                trainStolbcy2.Wagons.Add(sedentaryWagonEconom);

            for (int i = 0; i < 10; ++i)
                trainStolbcy3.Wagons.Add(sedentaryWagonEconom);

            context.ListOfRoutes.Add(routeMinskBorisov);
            context.ListOfRoutes.Add(routeMinskMolodechno);
            context.ListOfRoutes.Add(routeMinskPuhovichi);
            context.ListOfRoutes.Add(routeMinskStolbcy);
            //context.ListOfStationTypes.Add(new StationType() { Name = "FirstType" });
            //context.ListOfStationTypes.Add(new StationType() { Name = "SecondType" });
            //context.ListOfStationTypes.Add(new StationType() { Name = "ThirdType" });
            //Test of adding new element with foreign key
            //context.ListOfSeatSectors.Add(new SeatSector() {  NumberOfFirstSeat = 10, NumberOfLastSeat = 50,  TypeOfSeats = new SeatType() { CanBeUpper = false, Name = "FirstSeatType", PriceForKilometer = 20 } });
            base.Seed(context);
        }
    }
}
