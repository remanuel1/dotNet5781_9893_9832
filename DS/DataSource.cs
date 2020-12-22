using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DO;


namespace DS
{
    public static class DataSource
    {
        public static List<Bus> allBuses;
        public static List<BusStation> allBusesStations;
        public static List<LineStation> allLinesStation;
        public static List<FollowStations> allFollowStations;
        public static List<LineBus> allLines;
        
        static DataSource()
        {
            InitAllLists();
        }
        static void InitAllLists()
        {
            int speed = 100;
            allBuses = new List<Bus>
            {
                #region restart 20 buses
                new Bus //1
                {
                    numberLicense = "" + 12548022,
                    startActivity = DateTime.Parse("01.01.2020"),
                    sumKM = 0,
                    totalFuel = 1200,
                    Status = Status.ready,
                    sumKMFromLastTreat = 0,
                    lastTreat = DateTime.Parse("01.01.2020"),
                    deleted = false,
                },

                new Bus //2
                {
                    numberLicense = "" + 5284250,
                    startActivity = DateTime.Parse("08.01.2016"),
                    sumKM = 1000,
                    totalFuel = 800,
                    Status = Status.needTreat,
                    sumKMFromLastTreat = 200,
                    lastTreat = DateTime.Parse("01.01.2018"),
                    deleted = false,
                },

                new Bus //3
                {
                    numberLicense = "" + 28695248,
                    startActivity = DateTime.Parse("01.05.2020"),
                    sumKM = 100,
                    totalFuel = 500,
                    Status = Status.ready,
                    sumKMFromLastTreat = 0,
                    lastTreat = DateTime.Parse("01.05.2020"),
                    deleted = false,
                },

                new Bus //4
                {
                    numberLicense = "" + 1352531,
                    startActivity = DateTime.Parse("09.09.2020"),
                    sumKM = 0,
                    totalFuel = 1200,
                    Status = Status.ready,
                    sumKMFromLastTreat = 0,
                    lastTreat = DateTime.Parse("09.09.2020"),
                    deleted = false,
                },

                new Bus //5
                {
                    numberLicense = "" + 2280822,
                    startActivity = DateTime.Parse("15.10.2020"),
                    sumKM = 0,
                    totalFuel = 1200,
                    Status = Status.ready,
                    sumKMFromLastTreat = 0,
                    lastTreat = DateTime.Parse("15.10.2020"),
                    deleted = false,
                },

                new Bus //6
                {
                    numberLicense = "" + 26108567,
                    startActivity = DateTime.Parse("01.09.2019"),
                    sumKM = 400,
                    totalFuel = 1200,
                    Status = Status.needTreat,
                    sumKMFromLastTreat = 400,
                    lastTreat = DateTime.Parse("01.09.2019"),
                    deleted = false,
                },

                new Bus //7
                {
                    numberLicense = "" + 12855201,
                    startActivity = DateTime.Parse("01.12.2020"),
                    sumKM = 0,
                    totalFuel = 1200,
                    Status = Status.ready,
                    sumKMFromLastTreat = 0,
                    lastTreat = DateTime.Parse("01.12.2020"),
                    deleted = false,
                },

                new Bus //8
                {
                    numberLicense = "" + 3045403,
                    startActivity = DateTime.Parse("01.06.2019"),
                    sumKM = 344,
                    totalFuel = 120,
                    Status = Status.ready,
                    sumKMFromLastTreat = 344,
                    lastTreat = DateTime.Parse("01.06.2020"),
                    deleted = false,
                },

                new Bus //9
                {
                    numberLicense = "" + 1277096,
                    startActivity = DateTime.Parse("07.07.2017"),
                    sumKM = 770,
                    totalFuel = 500,
                    Status = Status.ready,
                    sumKMFromLastTreat = 50,
                    lastTreat = DateTime.Parse("01.12.2020"),
                    deleted = false,
                },

                new Bus //10
                {
                    numberLicense = "" + 1487520,
                    startActivity = DateTime.Parse("01.01.2016"),
                    sumKM = 20000,
                    totalFuel = 100,
                    Status = Status.ready,
                    sumKMFromLastTreat = 500,
                    lastTreat = DateTime.Parse("01.01.2020"),
                    deleted = false,
                },

                new Bus //11
                {
                    numberLicense = "" + 3462058,
                    startActivity = DateTime.Parse("01.01.2014"),
                    sumKM = 140000,
                    totalFuel = 200,
                    Status = Status.ready,
                    sumKMFromLastTreat = 100,
                    lastTreat = DateTime.Parse("01.11.2020"),
                    deleted = false,
                },

                new Bus //12
                {
                    numberLicense = "" + 3622541,
                    startActivity = DateTime.Parse("01.05.2015"),
                    sumKM = 100000,
                    totalFuel = 1100,
                    Status = Status.needTreat,
                    sumKMFromLastTreat = 19000,
                    lastTreat = DateTime.Parse("01.09.2019"),
                    deleted = false,
                },

                new Bus //13
                {
                    numberLicense = "" + 1210021,
                    startActivity = DateTime.Parse("01.06.2020"),
                    sumKM = 200,
                    totalFuel = 1000,
                    Status = Status.ready,
                    sumKMFromLastTreat = 200,
                    lastTreat = DateTime.Parse("01.06.2020"),
                    deleted = false,
                },

                new Bus //14
                {
                    numberLicense = "" + 6582451,
                    startActivity = DateTime.Parse("01.08.2017"),
                    sumKM = 50000,
                    totalFuel = 1200,
                    Status = Status.ready,
                    sumKMFromLastTreat = 10,
                    lastTreat = DateTime.Parse("20.12.2020"),
                    deleted = false,
                },

                new Bus //15
                {
                    numberLicense = "" + 1245421,
                    startActivity = DateTime.Parse("01.12.2020"),
                    sumKM = 0,
                    totalFuel = 1200,
                    Status = Status.ready,
                    sumKMFromLastTreat = 0,
                    lastTreat = DateTime.Parse("01.12.2020"),
                    deleted = false,
                },

                new Bus //16
                {
                    numberLicense = "" + 5248102,
                    startActivity = DateTime.Parse("01.01.2014"),
                    sumKM = 122500,
                    totalFuel = 400,
                    Status = Status.needTreat,
                    sumKMFromLastTreat = 14000,
                    lastTreat = DateTime.Parse("01.10.2019"),
                    deleted = false,
                },

                new Bus //17
                {
                    numberLicense = "" + 652846,
                    startActivity = DateTime.Parse("01.01.2017"),
                    sumKM = 362510,
                    totalFuel = 666,
                    Status = Status.ready,
                    sumKMFromLastTreat = 2000,
                    lastTreat = DateTime.Parse("01.10.2020"),
                    deleted = false,
                },

                new Bus //18
                {
                    numberLicense = "" + 6251002,
                    startActivity = DateTime.Parse("01.01.2013"),
                    sumKM = 152014,
                    totalFuel = 802,
                    Status = Status.ready,
                    sumKMFromLastTreat = 15000,
                    lastTreat = DateTime.Parse("01.03.2020"),
                    deleted = false,
                },

                new Bus //19
                {
                    numberLicense = "" + 5148235,
                    startActivity = DateTime.Parse("01.03.2016"),
                    sumKM = 165003,
                    totalFuel = 400,
                    Status = Status.ready,
                    sumKMFromLastTreat = 3000,
                    lastTreat = DateTime.Parse("01.08.2020"),
                    deleted = false,
                },

                new Bus //20
                {
                    numberLicense = "" + 12100121,
                    startActivity = DateTime.Parse("01.10.2020"),
                    sumKM = 150,
                    totalFuel = 1100,
                    Status = Status.ready,
                    sumKMFromLastTreat = 150,
                    lastTreat = DateTime.Parse("01.10.2020"),
                    deleted = false,
                },
                #endregion
            };

            allBusesStations = new List<BusStation>
            {
                #region restart 50 statins
                new BusStation //1
                {
                    numberStation=38831,
                    Latitude=32.183921,
                    Longitude=34.917806,
                    nameStation="Bar Lev School / Ben Yehuda",
                    address="Ben Yehuda 76, Kfar saba",
                    deleted=false,
                },

                new BusStation //2
                {
                    numberStation=38832,
                    Latitude=31.870034,
                    Longitude=34.819541,
                    nameStation="Herzel / Bilo",
                    address="Herzel, Kiryat Ekron",
                    deleted=false,
                },

                new BusStation //3
                {
                    numberStation=38833,
                    Latitude=31.984553,
                    Longitude=34.782828,
                    nameStation="Yasmin / Arar",
                    address="Yasmin 30, Rison Lezion",
                    deleted=false,
                },

                new BusStation //4
                {
                    numberStation=38834,
                    Latitude=31.88855,
                    Longitude=34.790904,
                    nameStation="Frid / Sheshet Hayamim",
                    address="Moshe Frid 9, Rehovot",
                    deleted=false,
                },

                new BusStation //5
                {
                    numberStation=38836,
                    Latitude=31.956392,
                    Longitude=34.898098,
                    nameStation="Central Station drop off, Lod",
                    address="Central Station, Lod",
                    deleted=false,
                },

                new BusStation //6
                {
                    numberStation=38837,
                    Latitude=31.892166,
                    Longitude=34.796071,
                    nameStation="Hana Avrech / Volkani",
                    address="Hana Avrech 15, Rehovot",
                    deleted=false,
                },

                new BusStation //7
                {
                    numberStation=38838,
                    Latitude=31.857565,
                    Longitude=34.824106,
                    nameStation="Herzel / Moshe Sharet",
                    address="Herzel 20, Kiryat Ekron",
                    deleted=false,
                },

                new BusStation //8
                {
                    numberStation=38839,
                    Latitude=31.862305,
                    Longitude=34.821857,
                    nameStation="Habanim / Eli Chohen",
                    address="Habanim 4, Kiryat Ekron",
                    deleted=false,
                },

                new BusStation //9
                {
                    numberStation=38840,
                    Latitude=31.865085,
                    Longitude=34.822237,
                    nameStation="Waizman / Habanim",
                    address="Waizman 11, Kiryat Ekron",
                    deleted=false,
                },

                new BusStation //10
                {
                    numberStation=38841,
                    Latitude=31.865222,
                    Longitude=34.818957,
                    nameStation="Hairus / Hakalanit",
                    address="Hairus 13, Kiryat Ekron",
                    deleted=false,

                },

                new BusStation //11
                {
                    numberStation=38842,
                    Latitude=31.867597,
                    Longitude=34.818392,
                    nameStation="Hakalanit / Hanarkis",
                    address="Hakalanit 1, Kiryat Ekron",
                    deleted=false,

                },

                new BusStation //12
                {
                    numberStation=38844,
                    Latitude=31.86244,
                    Longitude=34.827023,
                    nameStation="Eli Chohen / Lohami Hagetaot",
                    address="Eli Chohen 62, Kiryat Ekron",
                    deleted=false,

                },

                new BusStation //13
                {
                    numberStation=38845,
                    Latitude=31.863501,
                    Longitude=34.828702,
                    nameStation="Shabazi / Shevet Ahim",
                    address="Shabazi 51, Kiryat Ekron",
                    deleted=false,

                },

                new BusStation //14
                {
                    numberStation=38846,
                    Latitude=31.865348,
                    Longitude=34.827102,
                    nameStation="Shabazi / Waizman",
                    address="Shabazi 31, Kiryat Ekron",
                    deleted=false,

                },

                new BusStation //15
                {
                    numberStation=38847,
                    Latitude=31.977409,
                    Longitude=34.763896,
                    nameStation="Haim Bar Lev / Ytzak Rabin dw.",
                    address="Haim Bar Lev, Rison Lezion",
                    deleted=false,

                },

                new BusStation //16
                {
                    numberStation=38848,
                    Latitude=32.300345,
                    Longitude=34.912708,
                    nameStation="Len Hasharon Mental Health Center",
                    address="Tzur Moshe",
                    deleted=false,

                },

                new BusStation //17
                {
                    numberStation=38849,
                    Latitude=32.301347,
                    Longitude=34.912602,
                    nameStation="Len Hasharon Mental Health Center",
                    address="Tzur Moshe",
                    deleted=false,

                },

                new BusStation //18
                {
                    numberStation=38852,
                    Latitude=31.914255,
                    Longitude=34.807944,
                    nameStation="Holzman / Hamada",
                    address="Haim Holzman 2, Rehovot",
                    deleted=false,

                },

                new BusStation //19
                {
                    numberStation=38854,
                    Latitude=31.963668,
                    Longitude=34.836363,
                    nameStation="Mahane Tzrifin / Club",
                    address="Tzrifin",
                    deleted=false,

                },

                new BusStation //20
                {
                    numberStation=38855,
                    Latitude=31.856115,
                    Longitude=34.825249,
                    nameStation="Herzel / Golani",
                    address="Herzel 4, Kiryat Ekron",
                    deleted=false,

                },

                new BusStation //21
                {
                    numberStation=38856,
                    Latitude=31.874963,
                    Longitude=34.81249,
                    nameStation="Harotem / Hadganyot",
                    address="Harotem 3, Rehovot",
                    deleted=false,

                },

                new BusStation //22
                {
                    numberStation=38859,
                    Latitude=32.300035,
                    Longitude=34.910842,
                    nameStation="Haarava",
                    address="Haarava 1, Tzur Moshe",
                    deleted=false,
                },

                new BusStation //23
                {
                    numberStation=38860,
                    Latitude=32.305234,
                    Longitude=34.948647,
                    nameStation="Mevo Hagefen / Hateena",
                    address="Mevo Hagefen, Yanuv",
                    deleted=false,
                },

                new BusStation //24
                {
                    numberStation=38861,
                    Latitude=32.304022,
                    Longitude=34.943393,
                    nameStation="Mevo Hagefen / Haarhava",
                    address="Mevo Hagefen, Yanuv",
                    deleted=false,
                },

                new BusStation //25
                {
                    numberStation=38862,
                    Latitude=32.302957,
                    Longitude=34.940529,
                    nameStation="Haarhava A",
                    address="Haarhava, Geulim",
                    deleted=false,
                },

                new BusStation //26
                {
                    numberStation=38863,
                    Latitude=32.300264,
                    Longitude=34.939512,
                    nameStation="Haarhava B",
                    address="Haarhava, Geulim",
                    deleted=false,
                },

                new BusStation //27
                {
                    numberStation=38864,
                    Latitude=32.298171,
                    Longitude=34.938705,
                    nameStation="Haarhava / Vatikim",
                    address="Haarhava, Geulim",
                    deleted=false,
                },

                new BusStation //28
                {
                    numberStation=38865,
                    Latitude=31.998767,
                    Longitude=34.879725,
                    nameStation=" Airports / Aliyah",
                    address=" Aliya , Ben Gurion Airport",
                    deleted=false,
                },

                new BusStation //29
                {
                    numberStation= 38866,
                    Latitude=31.998767,
                    Longitude=34.879725,
                    nameStation=" Kanaf/ Barwash",
                    address=" Kanaf, Ben Gurion Airport  ",
                    deleted=false,
                },

                new BusStation //30
                {
                    numberStation=38867,
                    Latitude=31.883019,
                    Longitude=34.818708,
                    nameStation=" HaBurah/ Dov Hoz",
                    address=" HaBurah 24, Rehovot ",
                    deleted=false,
                },

               new BusStation //31
               {
                    numberStation=38869,
                    Latitude=32.349776,
                    Longitude=34.926837,
                    nameStation=" Beit Halevi",
                    address=" 100 105, Beit Halevi",
                    deleted=false,
               },

               new BusStation //32
               {
                    numberStation=38870,
                    Latitude=32.352953,
                    Longitude=34.899465,
                    nameStation=" The first / Route 5700",
                    address=" Migdal 13, Kfar Haim ",
                    deleted=false,
               },

               new BusStation //33
               {
                    numberStation=38872,
                    Latitude=31.897286,
                    Longitude=34.775083,
                    nameStation=" The genius Ben Ish Chai / Ceylon",
                    address="The genius Ben Ish Chai 20, Rehovot ",
                    deleted=false,
               },

               new BusStation //34
               {
                    numberStation=38873,
                    Latitude=31.883941,
                    Longitude=34.807039,
                    nameStation=" Okashi / Levi Eshkol",
                    address="Israel Okashi 4, Rehovot ",
                    deleted=false,
               },

                new BusStation //35
                {
                    numberStation=38875,
                    Latitude=31.896762,
                    Longitude=34.816752,
                    nameStation=" Menucha and Nahala / Yehuda Gorodiski",
                    address="Menucha and Nahala 31, Rehovot ",
                    deleted=false,
                },

                new BusStation //36
                {
                    numberStation=38876,
                    Latitude=31.898463,
                    Longitude=34.823461,
                    nameStation=" Gorodsky / Yechiel Paldi",
                    address="Yehuda Gorodisky 35, Rehovot",
                    deleted=false,
                },

                new BusStation //37
                {
                    numberStation=38877,
                    Latitude=32.076535,
                    Longitude=34.904907,
                    nameStation=" Derech Menachem Begin / Yaakov Hazan",
                    address="Derech Menachem Begin 30, Petah Tikva",
                    deleted=false,
                },

                new BusStation //38
                {
                    numberStation=38878,
                    Latitude=32.299994,
                    Longitude=34.878765,
                    nameStation=" Way the Park / Rabbi Neria",
                    address="Way the Park 20, Netanya",
                    deleted=false,
                },

                new BusStation //39
                {
                    numberStation=38879,
                    Latitude=31.865457,
                    Longitude=34.859437,
                    nameStation=" Hteana / Hgefan",
                    address="Hteana, Yaziz",
                    deleted=false,
                },

                new BusStation //40
                {
                    numberStation=38880,
                    Latitude=31.866772,
                    Longitude=34.864555,
                    nameStation=" Hteana / Halon",
                    address="Hteana, Yaziz",
                    deleted=false,
                },

                new BusStation //41
                {
                    numberStation=38880,
                    Latitude=31.866772,
                    Longitude=34.864555,
                    nameStation=" Hteana / Halon",
                    address="Hteana, Yaziz",
                    deleted=false,
                },

                new BusStation //42
                {
                    numberStation = 38881,
                    Latitude = 31.809325,
                    Longitude = 34.784347,
                    nameStation = " Way the Flowers / Jasmine",
                    address = "Way the Flowers 46, Gedera",
                    deleted = false,
                },

                new BusStation //43
                {
                    numberStation = 38883,
                    Latitude = 31.80037,
                    Longitude = 34.778239,
                    nameStation = " Yitzhak Rabin / Pinchas Sapir",
                    address = "Yitzhak Rabin, Gedera",
                    deleted = false,
                },

                new BusStation //44
                {   
                    numberStation = 38884,
                    Latitude = 31.799224,
                    Longitude = 34.782985,
                    nameStation = " Menachem Begin / Yitzhak Rabin",
                    address = "Menachem Begin 4, Gedera",
                    deleted = false,
                },

                new BusStation //45
                {
                    numberStation = 38885,
                    Latitude = 31.800334,
                    Longitude = 34.785069,
                    nameStation = " Haim Herzog / Dolev",
                    address = "Haim Herzog 12, Gedera",
                    deleted = false,
                },

                new BusStation //46
                {
                    numberStation = 38886,
                    Latitude = 31.802319,
                    Longitude = 34.786735,
                    nameStation = " Gvanim School / Erez ",
                    address = "Erez 2, Gedera",
                    deleted = false,
                },

                new BusStation //47
                {
                    numberStation = 38887,
                    Latitude = 31.804595,
                    Longitude = 34.786623,
                    nameStation = "Hailanot road/ Alon",
                    address = "Hailanot raod 13, Gedera",
                    deleted = false,
                },

                new BusStation //48
                {
                    numberStation = 38888,
                    Latitude = 31.805041,
                    Longitude = 34.785098,
                    nameStation = "Hailanot road / Menahem Begin  ",
                    address = "Hailanot raod 3, Gedera",
                    deleted = false,
                },

                new BusStation //49
                {
                    numberStation = 38889,
                    Latitude = 31.816751,
                    Longitude = 34.782252,
                    nameStation = "Haazmaut / Waiztman",
                    address = "Haazmaut 1 , Gedera",
                    deleted = false,
                },

                new BusStation //50
                {
                    numberStation = 38890,
                    Latitude = 31.816579,
                    Longitude = 34.779753,
                    nameStation = "Waiztman / Marvad Haksamim",
                    address = "Waiztman 19 , Gedera",
                    deleted = false,
                },
                #endregion
            };

            allLinesStation = new List<LineStation>
            {
                #region restart 100 line Stations
                new LineStation
                {
                    identifyLine = 1000,
                    numberStation = 38832,
                    numberStationInLine = 1,
                    deleted = false
                },

                new LineStation
                {
                    identifyLine = 1000,
                     numberStation = 38838,
                     numberStationInLine = 2,
                     deleted = false
                },

                new LineStation
                {
                    identifyLine = 1000,
                    numberStation = 38839,
                    numberStationInLine = 3,
                    deleted = false
                },

                new LineStation
                {
                    identifyLine = 1000,
                    numberStation = 38840,
                    numberStationInLine = 4,
                    deleted = false
                },

                new LineStation
                {
                    identifyLine = 1000,
                    numberStation = 38841,
                    numberStationInLine = 5,
                    deleted = false
                },

                new LineStation
                {
                    identifyLine = 1000,
                    numberStation = 38842,
                    numberStationInLine = 6,
                    deleted = false
                },

                new LineStation
                {
                    identifyLine = 1000,
                    numberStation = 38844,
                    numberStationInLine = 7,
                    deleted = false
                },

                new LineStation
                {
                    identifyLine = 1000,
                    numberStation = 38845,
                    numberStationInLine = 8,
                    deleted = false
                },

                new LineStation
                {
                    identifyLine = 1000,
                    numberStation = 38846,
                    numberStationInLine = 9,
                    deleted = false
                },

                new LineStation
                {
                    identifyLine = 1000,
                    numberStation = 38855,
                    numberStationInLine = 10,
                    deleted = false
                },

                new LineStation
                {
                    identifyLine = 1001,
                    numberStation = 38834,
                    numberStationInLine = 1,
                    deleted = false
                },

                new LineStation
                {
                     identifyLine = 1001,
                     numberStation = 38837,
                     numberStationInLine = 2,
                     deleted = false
                },

                new LineStation
                {
                    identifyLine = 1001,
                    numberStation = 38856,
                    numberStationInLine = 3,
                    deleted = false
                },

                new LineStation
                {
                    identifyLine = 1001,
                    numberStation = 38867,
                    numberStationInLine = 4,
                    deleted = false
                },

                new LineStation
                {
                    identifyLine = 1001,
                    numberStation = 38841,
                    numberStationInLine = 5,
                    deleted = false
                },

                new LineStation
                {
                    identifyLine = 1001,
                    numberStation = 38873,
                    numberStationInLine = 6,
                    deleted = false
                },

                new LineStation
                {
                    identifyLine = 1001,
                    numberStation = 38875,
                    numberStationInLine = 7,
                    deleted = false
                },

                new LineStation
                {
                    identifyLine = 1001,
                    numberStation = 38876,
                    numberStationInLine = 8,
                    deleted = false
                },

                new LineStation
                {
                    identifyLine = 1001,
                    numberStation = 38832,
                    numberStationInLine = 9,
                    deleted = false
                },

                new LineStation
                {
                    identifyLine = 1001,
                    numberStation = 38838,
                    numberStationInLine = 10,
                    deleted = false
                },

                new LineStation
                {
                    identifyLine = 1002,
                    numberStation = 38859,
                    numberStationInLine = 1,
                    deleted = false
                },

                 new LineStation
                 {
                     identifyLine = 1002,
                     numberStation = 38860,
                     numberStationInLine = 2,
                     deleted = false
                 },

                new LineStation
                {
                    identifyLine = 1002,
                    numberStation = 38861,
                    numberStationInLine = 3,
                    deleted = false
                },

                new LineStation
                {
                    identifyLine = 1002,
                    numberStation = 38862,
                    numberStationInLine = 4,
                    deleted = false
                },

                new LineStation
                {
                    identifyLine = 1002,
                    numberStation = 38863,
                    numberStationInLine = 5,
                    deleted = false
                },

                new LineStation
                {
                    identifyLine = 1002,
                    numberStation = 38864,
                    numberStationInLine = 6,
                    deleted = false
                },

                new LineStation
                {
                    identifyLine = 1002,
                    numberStation = 38865,
                    numberStationInLine = 7,
                    deleted = false
                },

                new LineStation
                {
                    identifyLine = 1002,
                    numberStation = 38866,
                    numberStationInLine = 8,
                    deleted = false
                },

                new LineStation
                {
                    identifyLine = 1002,
                    numberStation = 38867,
                    numberStationInLine = 9,
                    deleted = false
                },

                new LineStation
                {
                    identifyLine = 1002,
                    numberStation = 38869,
                    numberStationInLine = 10,
                    deleted = false
                },

                new LineStation
                {
                    identifyLine = 1003,
                    numberStation = 38846,
                    numberStationInLine = 1,
                    deleted = false
                },

                new LineStation
                {
                    identifyLine = 1003,
                     numberStation = 38845,
                     numberStationInLine = 2,
                     deleted = false
                },

                new LineStation
                {
                    identifyLine = 1003,
                    numberStation = 38844,
                    numberStationInLine = 3,
                    deleted = false
                },

                new LineStation
                {
                    identifyLine = 1003,
                    numberStation = 38842,
                    numberStationInLine = 4,
                    deleted = false
                },

                new LineStation
                {
                    identifyLine = 1003,
                    numberStation = 38841,
                    numberStationInLine = 5,
                    deleted = false
                },

                new LineStation
                {
                    identifyLine = 1003,
                    numberStation = 38840,
                    numberStationInLine = 6,
                    deleted = false
                },

                new LineStation
                {
                    identifyLine = 1003,
                    numberStation = 38839,
                    numberStationInLine = 7,
                    deleted = false
                },

                new LineStation
                {
                    identifyLine = 1003,
                    numberStation = 38838,
                    numberStationInLine = 8,
                    deleted = false
                },

                new LineStation
                {
                    identifyLine = 1003,
                    numberStation = 38837,
                    numberStationInLine = 9,
                    deleted = false
                },

                new LineStation
                {
                    identifyLine = 1003,
                    numberStation = 38836,
                    numberStationInLine = 10,
                    deleted = false
                },

                new LineStation
                {
                    identifyLine = 1004,
                    numberStation = 38880,
                    numberStationInLine = 1,
                    deleted = false
                },

                new LineStation
                {
                    identifyLine = 1004,
                     numberStation = 38881,
                     numberStationInLine = 2,
                     deleted = false
                },

                new LineStation
                {
                    identifyLine = 1004,
                    numberStation = 38883,
                    numberStationInLine = 3,
                    deleted = false
                },

                new LineStation
                {
                    identifyLine = 1004,
                    numberStation = 38884,
                    numberStationInLine = 4,
                    deleted = false
                },

                new LineStation
                {
                    identifyLine = 1004,
                    numberStation = 38885,
                    numberStationInLine = 5,
                    deleted = false
                },

                new LineStation
                {
                    identifyLine = 1004,
                    numberStation = 38886,
                    numberStationInLine = 6,
                    deleted = false
                },

                new LineStation
                {
                    identifyLine = 1004,
                    numberStation = 38887,
                    numberStationInLine = 7,
                    deleted = false
                },

                new LineStation
                {
                    identifyLine = 1004,
                    numberStation = 38888,
                    numberStationInLine = 8,
                    deleted = false
                },

                new LineStation
                {
                    identifyLine = 1004,
                    numberStation = 38889,
                    numberStationInLine = 9,
                    deleted = false
                },

                new LineStation
                {
                    identifyLine = 1004,
                    numberStation = 38890,
                    numberStationInLine = 10,
                    deleted = false
                },

                new LineStation
                {
                    identifyLine = 1005,
                    numberStation = 38884,
                    numberStationInLine = 1,
                    deleted = false
                },

                new LineStation
                {
                    identifyLine = 1005,
                     numberStation = 38885,
                     numberStationInLine = 2,
                     deleted = false
                },

                new LineStation
                {
                    identifyLine = 1005,
                    numberStation = 38883,
                    numberStationInLine = 3,
                    deleted = false
                },

                new LineStation
                {
                    identifyLine = 1005,
                    numberStation = 38886,
                    numberStationInLine = 4,
                    deleted = false
                },

                new LineStation
                {
                    identifyLine = 1005,
                    numberStation = 38887,
                    numberStationInLine = 5,
                    deleted = false
                },

                new LineStation
                {
                    identifyLine = 1005,
                    numberStation = 38888,
                    numberStationInLine = 6,
                    deleted = false
                },

                new LineStation
                {
                    identifyLine = 1005,
                    numberStation = 38881,
                    numberStationInLine = 7,
                    deleted = false
                },

                new LineStation
                {
                    identifyLine = 1005,
                    numberStation = 38890,
                    numberStationInLine = 8,
                    deleted = false
                },

                new LineStation
                {
                    identifyLine = 1005,
                    numberStation = 38889,
                    numberStationInLine = 9,
                    deleted = false
                },

                new LineStation
                {
                    identifyLine = 1005,
                    numberStation = 38855,
                    numberStationInLine = 10,
                    deleted = false
                },

                new LineStation
                {
                    identifyLine = 1006,
                    numberStation = 38838,
                    numberStationInLine = 1,
                    deleted = false
                },

                new LineStation
                {
                    identifyLine = 1006,
                     numberStation = 38839,
                     numberStationInLine = 2,
                     deleted = false
                },

                new LineStation
                {
                    identifyLine = 1006,
                    numberStation = 38844,
                    numberStationInLine = 3,
                    deleted = false
                },

                new LineStation
                {
                    identifyLine = 1006,
                    numberStation = 38845,
                    numberStationInLine = 4,
                    deleted = false
                },

                new LineStation
                {
                    identifyLine = 1006,
                    numberStation = 38840,
                    numberStationInLine = 5,
                    deleted = false
                },

                new LineStation
                {
                    identifyLine = 1006,
                    numberStation = 38841,
                    numberStationInLine = 6,
                    deleted = false
                },

                new LineStation
                {
                    identifyLine = 1006,
                    numberStation = 38846,
                    numberStationInLine = 7,
                    deleted = false
                },

                new LineStation
                {
                    identifyLine = 1006,
                    numberStation = 38842,
                    numberStationInLine = 8,
                    deleted = false
                },

                new LineStation
                {
                    identifyLine = 1006,
                    numberStation = 38879,
                    numberStationInLine = 9,
                    deleted = false
                },

                new LineStation
                {
                    identifyLine = 1006,
                    numberStation = 38880,
                    numberStationInLine = 10,
                    deleted = false
                },

                new LineStation
                {
                    identifyLine = 1007,
                    numberStation = 38832,
                    numberStationInLine = 1,
                    deleted = false
                },

                new LineStation
                {
                    identifyLine = 1007,
                     numberStation = 38856,
                     numberStationInLine = 2,
                     deleted = false
                },

                new LineStation
                {
                    identifyLine = 1007,
                    numberStation = 38867,
                    numberStationInLine = 3,
                    deleted = false
                },

                new LineStation
                {
                    identifyLine = 1007,
                    numberStation = 38873,
                    numberStationInLine = 4,
                    deleted = false
                },

                new LineStation
                {
                    identifyLine = 1007,
                    numberStation = 38834,
                    numberStationInLine = 5,
                    deleted = false
                },

                new LineStation
                {
                    identifyLine = 1007,
                    numberStation = 38837,
                    numberStationInLine = 6,
                    deleted = false
                },

                new LineStation
                {
                    identifyLine = 1007,
                    numberStation = 38875,
                    numberStationInLine = 7,
                    deleted = false
                },

                new LineStation
                {
                    identifyLine = 1007,
                    numberStation = 38872,
                    numberStationInLine = 8,
                    deleted = false
                },

                new LineStation
                {
                    identifyLine = 1007,
                    numberStation = 38876,
                    numberStationInLine = 9,
                    deleted = false
                },

                new LineStation
                {
                    identifyLine = 1007,
                    numberStation = 38852,
                    numberStationInLine = 10,
                    deleted = false
                },

                new LineStation
                {
                    identifyLine = 1008,
                    numberStation = 38852,
                    numberStationInLine = 1,
                    deleted = false
                },

                new LineStation
                {
                    identifyLine = 1008,
                     numberStation = 38854,
                     numberStationInLine = 2,
                     deleted = false
                },

                new LineStation
                {
                    identifyLine = 1008,
                    numberStation = 38847,
                    numberStationInLine = 3,
                    deleted = false
                },

                new LineStation
                {
                    identifyLine = 1008,
                    numberStation = 38833,
                    numberStationInLine = 4,
                    deleted = false
                },

                new LineStation
                {
                    identifyLine = 1008,
                    numberStation = 38865,
                    numberStationInLine = 5,
                    deleted = false
                },

                new LineStation
                {
                    identifyLine = 1008,
                    numberStation = 38866,
                    numberStationInLine = 6,
                    deleted = false
                },

                new LineStation
                {
                    identifyLine = 1008,
                    numberStation = 38877,
                    numberStationInLine = 7,
                    deleted = false
                },

                new LineStation
                {
                    identifyLine = 1008,
                    numberStation = 38831,
                    numberStationInLine = 8,
                    deleted = false
                },

                new LineStation
                {
                    identifyLine = 1008,
                    numberStation = 38864,
                    numberStationInLine = 9,
                    deleted = false
                },

                new LineStation
                {
                    identifyLine = 1008,
                    numberStation = 38878,
                    numberStationInLine = 10,
                    deleted = false
                },

                new LineStation
                {
                    identifyLine = 1009,
                    numberStation = 38832,
                    numberStationInLine = 1,
                    deleted = false
                },

                new LineStation
                {
                    identifyLine = 1009,
                     numberStation = 38856,
                     numberStationInLine = 2,
                     deleted = false
                },

                new LineStation
                {
                    identifyLine = 1009,
                    numberStation = 38867,
                    numberStationInLine = 3,
                    deleted = false
                },

                new LineStation
                {
                    identifyLine = 1009,
                    numberStation = 38873,
                    numberStationInLine = 4,
                    deleted = false
                },

                new LineStation
                {
                    identifyLine = 1009,
                    numberStation = 38834,
                    numberStationInLine = 5,
                    deleted = false
                },

                new LineStation
                {
                    identifyLine = 1009,
                    numberStation = 38837,
                    numberStationInLine = 6,
                    deleted = false
                },

                new LineStation
                {
                    identifyLine = 1009,
                    numberStation = 38875,
                    numberStationInLine = 7,
                    deleted = false
                },

                new LineStation
                {
                    identifyLine = 1009,
                    numberStation = 38872,
                    numberStationInLine = 8,
                    deleted = false
                },

                new LineStation
                {
                    identifyLine = 1009,
                    numberStation = 38876,
                    numberStationInLine = 9,
                    deleted = false
                },

                new LineStation
                {
                    identifyLine = 1009,
                    numberStation = 38852,
                    numberStationInLine = 10,
                    deleted = false
                },
                #endregion
            };
            allFollowStations = new List<FollowStations>
            {
                #region restart all follow stations
                new FollowStations
                {
                    numberStation1= 38832,
                    numberStation2= 38838,
                    distance = 0.013278,
                    drivinngTime= TimeSpan.FromMinutes(0.013278/speed),
                }
            };




        }
    }
}
