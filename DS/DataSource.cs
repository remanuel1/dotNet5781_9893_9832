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
        public static List<ExitLine> allExitLines;
        public static List<User> allUsers;

        static DataSource()
        {
            InitAllLists();
        }
        static void InitAllLists()
        {
            double speed = 50;
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
                    numberLicense = "" + 6528456,
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
                    Longitude=32.183921,
                    Latitude=34.917806,
                    nameStation="Bar Lev School / Ben Yehuda",
                    address="Ben Yehuda 76, Kfar saba",
                    deleted=false,
                },

                new BusStation //2
                {
                    numberStation=38832,
                    Longitude=31.870034,
                    Latitude=34.819541,
                    nameStation="Herzel / Bilo",
                    address="Herzel, Kiryat Ekron",
                    deleted=false,
                },

                new BusStation //3
                {
                    numberStation=38833,
                    Longitude=31.984553,
                    Latitude=34.782828,
                    nameStation="Yasmin / Arar",
                    address="Yasmin 30, Rison Lezion",
                    deleted=false,
                },

                new BusStation //4
                {
                    numberStation=38834,
                    Longitude=31.88855,
                    Latitude=34.790904,
                    nameStation="Frid / Sheshet Hayamim",
                    address="Moshe Frid 9, Rehovot",
                    deleted=false,
                },

                new BusStation //5
                {
                    numberStation=38836,
                    Longitude=31.956392,
                    Latitude=34.898098,
                    nameStation="Central Station drop off, Lod",
                    address="Central Station, Lod",
                    deleted=false,
                },

                new BusStation //6
                {
                    numberStation=38837,
                    Longitude=31.892166,
                    Latitude=34.796071,
                    nameStation="Hana Avrech / Volkani",
                    address="Hana Avrech 15, Rehovot",
                    deleted=false,
                },

                new BusStation //7
                {
                    numberStation=38838,
                    Longitude=31.857565,
                    Latitude=34.824106,
                    nameStation="Herzel / Moshe Sharet",
                    address="Herzel 20, Kiryat Ekron",
                    deleted=false,
                },

                new BusStation //8
                {
                    numberStation=38839,
                    Longitude=31.862305,
                    Latitude=34.821857,
                    nameStation="Habanim / Eli Chohen",
                    address="Habanim 4, Kiryat Ekron",
                    deleted=false,
                },

                new BusStation //9
                {
                    numberStation=38840,
                    Longitude=31.865085,
                    Latitude=34.822237,
                    nameStation="Waizman / Habanim",
                    address="Waizman 11, Kiryat Ekron",
                    deleted=false,
                },

                new BusStation //10
                {
                    numberStation=38841,
                    Longitude=31.865222,
                    Latitude=34.818957,
                    nameStation="Hairus / Hakalanit",
                    address="Hairus 13, Kiryat Ekron",
                    deleted=false,

                },

                new BusStation //11
                {
                    numberStation=38842,
                    Longitude=31.867597,
                    Latitude=34.818392,
                    nameStation="Hakalanit / Hanarkis",
                    address="Hakalanit 1, Kiryat Ekron",
                    deleted=false,

                },

                new BusStation //12
                {
                    numberStation=38844,
                    Longitude=31.86244,
                    Latitude=34.827023,
                    nameStation="Eli Chohen / Lohami Hagetaot",
                    address="Eli Chohen 62, Kiryat Ekron",
                    deleted=false,

                },

                new BusStation //13
                {
                    numberStation=38845,
                    Longitude=31.863501,
                    Latitude=34.828702,
                    nameStation="Shabazi / Shevet Ahim",
                    address="Shabazi 51, Kiryat Ekron",
                    deleted=false,

                },

                new BusStation //14
                {
                    numberStation=38846,
                    Longitude=31.865348,
                    Latitude=34.827102,
                    nameStation="Shabazi / Waizman",
                    address="Shabazi 31, Kiryat Ekron",
                    deleted=false,

                },

                new BusStation //15
                {
                    numberStation=38847,
                    Longitude=31.977409,
                    Latitude=34.763896,
                    nameStation="Haim Bar Lev / Ytzak Rabin dw.",
                    address="Haim Bar Lev, Rison Lezion",
                    deleted=false,

                },

                new BusStation //16
                {
                    numberStation=38848,
                    Longitude=32.300345,
                    Latitude=34.912708,
                    nameStation="Len Hasharon Mental Health Center",
                    address="Tzur Moshe",
                    deleted=false,

                },

                new BusStation //17
                {
                    numberStation=38849,
                    Longitude=32.301347,
                    Latitude=34.912602,
                    nameStation="Len Hasharon Mental Health Center",
                    address="Tzur Moshe",
                    deleted=false,

                },

                new BusStation //18
                {
                    numberStation=38852,
                    Longitude=31.914255,
                    Latitude=34.807944,
                    nameStation="Holzman / Hamada",
                    address="Haim Holzman 2, Rehovot",
                    deleted=false,

                },

                new BusStation //19
                {
                    numberStation=38854,
                    Longitude=31.963668,
                    Latitude=34.836363,
                    nameStation="Mahane Tzrifin / Club",
                    address="Tzrifin",
                    deleted=false,

                },

                new BusStation //20
                {
                    numberStation=38855,
                    Longitude=31.856115,
                    Latitude=34.825249,
                    nameStation="Herzel / Golani",
                    address="Herzel 4, Kiryat Ekron",
                    deleted=false,

                },

                new BusStation //21
                {
                    numberStation=38856,
                    Longitude=31.874963,
                    Latitude=34.81249,
                    nameStation="Harotem / Hadganyot",
                    address="Harotem 3, Rehovot",
                    deleted=false,

                },

                new BusStation //22
                {
                    numberStation=38859,
                    Longitude=32.300035,
                    Latitude=34.910842,
                    nameStation="Haarava",
                    address="Haarava 1, Tzur Moshe",
                    deleted=false,
                },

                new BusStation //23
                {
                    numberStation=38860,
                    Longitude=32.305234,
                    Latitude=34.948647,
                    nameStation="Mevo Hagefen / Hateena",
                    address="Mevo Hagefen, Yanuv",
                    deleted=false,
                },

                new BusStation //24
                {
                    numberStation=38861,
                    Longitude=32.304022,
                    Latitude=34.943393,
                    nameStation="Mevo Hagefen / Haarhava",
                    address="Mevo Hagefen, Yanuv",
                    deleted=false,
                },

                new BusStation //25
                {
                    numberStation=38862,
                    Longitude=32.302957,
                    Latitude=34.940529,
                    nameStation="Haarhava A",
                    address="Haarhava, Geulim",
                    deleted=false,
                },

                new BusStation //26
                {
                    numberStation=38863,
                    Longitude=32.300264,
                    Latitude=34.939512,
                    nameStation="Haarhava B",
                    address="Haarhava, Geulim",
                    deleted=false,
                },

                new BusStation //27
                {
                    numberStation=38864,
                    Longitude=32.298171,
                    Latitude=34.938705,
                    nameStation="Haarhava / Vatikim",
                    address="Haarhava, Geulim",
                    deleted=false,
                },

                new BusStation //28
                {
                    numberStation=38865,
                    Longitude=31.998767,
                    Latitude=34.879725,
                    nameStation=" Airports / Aliyah",
                    address=" Aliya , Ben Gurion Airport",
                    deleted=false,
                },

                new BusStation //29
                {
                    numberStation= 38866,
                    Longitude=31.998767,
                    Latitude=34.879725,
                    nameStation=" Kanaf/ Barwash",
                    address=" Kanaf, Ben Gurion Airport  ",
                    deleted=false,
                },

                new BusStation //30
                {
                    numberStation=38867,
                    Longitude=31.883019,
                    Latitude=34.818708,
                    nameStation=" HaBurah/ Dov Hoz",
                    address=" HaBurah 24, Rehovot ",
                    deleted=false,
                },

               new BusStation //31
               {
                    numberStation=38869,
                    Longitude=32.349776,
                    Latitude=34.926837,
                    nameStation=" Beit Halevi",
                    address=" 100 105, Beit Halevi",
                    deleted=false,
               },

               new BusStation //32
               {
                    numberStation=38870,
                    Longitude=32.352953,
                    Latitude=34.899465,
                    nameStation=" The first / Route 5700",
                    address=" Migdal 13, Kfar Haim ",
                    deleted=false,
               },

               new BusStation //33
               {
                    numberStation=38872,
                    Longitude=31.897286,
                    Latitude=34.775083,
                    nameStation=" The genius Ben Ish Chai / Ceylon",
                    address="The genius Ben Ish Chai 20, Rehovot ",
                    deleted=false,
               },

               new BusStation //34
               {
                    numberStation=38873,
                    Longitude=31.883941,
                    Latitude=34.807039,
                    nameStation=" Okashi / Levi Eshkol",
                    address="Israel Okashi 4, Rehovot ",
                    deleted=false,
               },

                new BusStation //35
                {
                    numberStation=38875,
                    Longitude=31.896762,
                    Latitude=34.816752,
                    nameStation=" Menucha and Nahala / Yehuda Gorodiski",
                    address="Menucha and Nahala 31, Rehovot ",
                    deleted=false,
                },

                new BusStation //36
                {
                    numberStation=38876,
                    Longitude=31.898463,
                    Latitude=34.823461,
                    nameStation=" Gorodsky / Yechiel Paldi",
                    address="Yehuda Gorodisky 35, Rehovot",
                    deleted=false,
                },

                new BusStation //37
                {
                    numberStation=38877,
                    Longitude=32.076535,
                    Latitude=34.904907,
                    nameStation=" Derech Menachem Begin / Yaakov Hazan",
                    address="Derech Menachem Begin 30, Petah Tikva",
                    deleted=false,
                },

                new BusStation //38
                {
                    numberStation=38878,
                    Longitude=32.299994,
                    Latitude=34.878765,
                    nameStation=" Way the Park / Rabbi Neria",
                    address="Way the Park 20, Netanya",
                    deleted=false,
                },

                new BusStation //39
                {
                    numberStation=38879,
                    Longitude=31.865457,
                    Latitude=34.859437,
                    nameStation=" Hteana / Hgefan",
                    address="Hteana, Yaziz",
                    deleted=false,
                },

                new BusStation //40
                {
                    numberStation=38880,
                    Longitude=31.866772,
                    Latitude=34.864555,
                    nameStation=" Hteana / Halon",
                    address="Hteana, Yaziz",
                    deleted=false,
                },

                new BusStation //41
                {
                    numberStation=38880,
                    Longitude=31.866772,
                    Latitude=34.864555,
                    nameStation=" Hteana / Halon",
                    address="Hteana, Yaziz",
                    deleted=false,
                },

                new BusStation //42
                {
                    numberStation = 38881,
                    Longitude = 31.809325,
                    Latitude = 34.784347,
                    nameStation = " Way the Flowers / Jasmine",
                    address = "Way the Flowers 46, Gedera",
                    deleted = false,
                },

                new BusStation //43
                {
                    numberStation = 38883,
                    Longitude = 31.80037,
                    Latitude = 34.778239,
                    nameStation = " Yitzhak Rabin / Pinchas Sapir",
                    address = "Yitzhak Rabin, Gedera",
                    deleted = false,
                },

                new BusStation //44
                {
                    numberStation = 38884,
                    Longitude = 31.799224,
                    Latitude = 34.782985,
                    nameStation = " Menachem Begin / Yitzhak Rabin",
                    address = "Menachem Begin 4, Gedera",
                    deleted = false,
                },

                new BusStation //45
                {
                    numberStation = 38885,
                    Longitude = 31.800334,
                    Latitude = 34.785069,
                    nameStation = " Haim Herzog / Dolev",
                    address = "Haim Herzog 12, Gedera",
                    deleted = false,
                },

                new BusStation //46
                {
                    numberStation = 38886,
                    Longitude = 31.802319,
                    Latitude = 34.786735,
                    nameStation = " Gvanim School / Erez ",
                    address = "Erez 2, Gedera",
                    deleted = false,
                },

                new BusStation //47
                {
                    numberStation = 38887,
                    Longitude = 31.804595,
                    Latitude = 34.786623,
                    nameStation = "Hailanot road/ Alon",
                    address = "Hailanot raod 13, Gedera",
                    deleted = false,
                },

                new BusStation //48
                {
                    numberStation = 38888,
                    Longitude = 31.805041,
                    Latitude = 34.785098,
                    nameStation = "Hailanot road / Menahem Begin  ",
                    address = "Hailanot raod 3, Gedera",
                    deleted = false,
                },

                new BusStation //49
                {
                    numberStation = 38889,
                    Longitude = 31.816751,
                    Latitude = 34.782252,
                    nameStation = "Haazmaut / Waiztman",
                    address = "Haazmaut 1 , Gedera",
                    deleted = false,
                },

                new BusStation //50
                {
                    numberStation = 38890,
                    Longitude = 31.816579,
                    Latitude = 34.779753,
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
                // add deleted
                #region restart all follow stations
                new FollowStations
                {
                    numberStation1= 38832,
                    numberStation2= 38838,
                    distance = 600,
                    deleted = false,
                    drivinngTime= TimeSpan.FromMinutes(600/speed),
                },

                new FollowStations
                {
                    numberStation1= 38838,
                    numberStation2= 38839,
                    distance = 0.5246485,
                    drivinngTime= TimeSpan.FromMinutes(0.5246485/speed),
                },

                new FollowStations
                {
                    numberStation1= 38839,
                    numberStation2= 38840,
                    distance = 0.002805851,
                    drivinngTime= TimeSpan.FromMinutes(0.002805851/speed),
                },

                new FollowStations
                {
                    numberStation1= 38840,
                    numberStation2= 38841,
                    distance = 0.00328286,
                    drivinngTime= TimeSpan.FromMinutes(0.00328286/speed),
                },

                new FollowStations
                {
                    numberStation1= 38841,
                    numberStation2= 38842,
                    distance = 0.00244128,
                    drivinngTime= TimeSpan.FromMinutes(0.00244128/speed),
                },

                new FollowStations
                {
                    numberStation1= 38842,
                    numberStation2= 38844,
                    distance = 0.010054293,
                    drivinngTime= TimeSpan.FromMinutes(0.010054293/speed),
                },

                new FollowStations
                {
                    numberStation1= 38844,
                    numberStation2= 38845,
                    distance = 0.001986142,
                    drivinngTime= TimeSpan.FromMinutes(0.001986142/speed),
                },

                new FollowStations
                {
                    numberStation1= 38845,
                    numberStation2= 38846,
                    distance = 0.002443647,
                    drivinngTime= TimeSpan.FromMinutes(0.002443647/speed),
                },

                new FollowStations
                {
                    numberStation1= 38846,
                    numberStation2= 38855,
                    distance = 0.009417107,
                    drivinngTime= TimeSpan.FromMinutes(0.009417107/speed),
                },

                new FollowStations
                {
                    numberStation1= 38834,
                    numberStation2= 38837,
                    distance = 0.006306611,
                    drivinngTime= TimeSpan.FromMinutes(0.006306611/speed),
                },

                new FollowStations
                {
                    numberStation1= 38837,
                    numberStation2= 38856,
                    distance = 0.023780807,
                    drivinngTime= TimeSpan.FromMinutes(0.023780807/speed),
                },

                new FollowStations
                {
                    numberStation1= 38856,
                    numberStation2= 38867,
                    distance = 0.010176574,
                    drivinngTime= TimeSpan.FromMinutes(0.010176574/speed),
                },

                new FollowStations
                {
                    numberStation1= 38867,
                    numberStation2= 38841,
                    distance = 0.017798742,
                    drivinngTime= TimeSpan.FromMinutes(0.017798742/speed),
                },

                new FollowStations
                {
                    numberStation1= 38841,
                    numberStation2= 38873,
                    distance = 0.022190982,
                    drivinngTime= TimeSpan.FromMinutes(0.022190982/speed),
                },

                new FollowStations
                {
                    numberStation1= 38873,
                    numberStation2= 38875,
                    distance = 0.016084788,
                    drivinngTime= TimeSpan.FromMinutes(0.016084788/speed),
                },

                new FollowStations
                {
                    numberStation1= 38875,
                    numberStation2= 38876,
                    distance = 0.006921277,
                    drivinngTime= TimeSpan.FromMinutes(0.006921277/speed),
                },

                new FollowStations
                {
                    numberStation1= 38876,
                    numberStation2= 38832,
                    distance = 0.028697987,
                    drivinngTime= TimeSpan.FromMinutes(0.028697987/speed),
                },

                new FollowStations
                {
                    numberStation1= 38832,
                    numberStation2= 38838,
                    distance = 0.013278373,
                    drivinngTime= TimeSpan.FromMinutes(0.013278373/speed),
                },

                new FollowStations
                {
                    numberStation1= 38859,
                    numberStation2= 38860,
                    distance = 0.038160813,
                    drivinngTime= TimeSpan.FromMinutes(0.038160813/speed),
                },

                new FollowStations
                {
                    numberStation1= 38860,
                    numberStation2= 38861,
                    distance = 0.005391981,
                    drivinngTime= TimeSpan.FromMinutes(0.005391981/speed),
                },

                new FollowStations
                {
                    numberStation1= 38861,
                    numberStation2= 38862,
                    distance = 0.003055605,
                    drivinngTime= TimeSpan.FromMinutes(0.003055605/speed),
                },

                new FollowStations
                {
                    numberStation1= 38862,
                    numberStation2= 38863,
                    distance = 0.002878635,
                    drivinngTime= TimeSpan.FromMinutes(0.002878635/speed),
                },

                new FollowStations
                {
                    numberStation1= 38863,
                    numberStation2= 38864,
                    distance = 0.002243189,
                    drivinngTime= TimeSpan.FromMinutes(0.002243189/speed),
                },

                new FollowStations
                {
                    numberStation1= 38864,
                    numberStation2= 38865,
                    distance = 0.310031995,
                    drivinngTime= TimeSpan.FromMinutes(0.310031995/speed),
                },

                new FollowStations
                {
                    numberStation1= 38865,
                    numberStation2= 38866,
                    distance = 0.019539281,
                    drivinngTime= TimeSpan.FromMinutes(0.019539281/speed),
                },

                new FollowStations
                {
                    numberStation1= 38866,
                    numberStation2= 38867,
                    distance = 0.130845993,
                    drivinngTime= TimeSpan.FromMinutes(0.130845993/speed),
                },

                new FollowStations
                {
                    numberStation1= 38867,
                    numberStation2= 38869,
                    distance = 0.479117916,
                    drivinngTime= TimeSpan.FromMinutes(0.479117916/speed),
                },

                new FollowStations
                {
                    numberStation1= 38869,
                    numberStation2= 38846,
                    distance = 0.494588271,
                    drivinngTime= TimeSpan.FromMinutes(0.494588271/speed),
                },

                new FollowStations
                {
                    numberStation1= 38846,
                    numberStation2= 38845,
                    distance = 0.002443647,
                    drivinngTime= TimeSpan.FromMinutes(0.002443647/speed),
                },

                new FollowStations
                {
                    numberStation1= 38845,
                    numberStation2= 38844,
                    distance = 0.001986142,
                    drivinngTime= TimeSpan.FromMinutes(0.001986142/speed),
                },

                new FollowStations
                {
                    numberStation1= 38844,
                    numberStation2= 38842,
                    distance = 0.010054293,
                    drivinngTime= TimeSpan.FromMinutes(0.010054293/speed),
                },

                new FollowStations
                {
                    numberStation1= 38842,
                    numberStation2= 38841,
                    distance = 0.00244128,
                    drivinngTime= TimeSpan.FromMinutes(0.00244128/speed),
                },

                new FollowStations
                {
                    numberStation1= 38841,
                    numberStation2= 38840,
                    distance = 0.00328286,
                    drivinngTime= TimeSpan.FromMinutes(0.00328286/speed),
                },

                new FollowStations
                {
                    numberStation1= 38840,
                    numberStation2= 38839,
                    distance = 0.002805851,
                    drivinngTime= TimeSpan.FromMinutes(0.002805851/speed),
                },

                new FollowStations
                {
                    numberStation1= 38839,
                    numberStation2= 38838,
                    distance = 0.005246485,
                    drivinngTime= TimeSpan.FromMinutes(0.005246485/speed),
                },

                new FollowStations
                {
                    numberStation1= 38838,
                    numberStation2= 38837,
                    distance = 0.044533026,
                    drivinngTime= TimeSpan.FromMinutes(0.044533026/speed),
                },

                new FollowStations
                {
                    numberStation1= 38837,
                    numberStation2= 38836,
                    distance = 0.120559064,
                    drivinngTime= TimeSpan.FromMinutes(0.120559064/speed),
                },

                new FollowStations
                {
                    numberStation1= 38836,
                    numberStation2= 38880,
                    distance = 0.095691574,
                    drivinngTime= TimeSpan.FromMinutes(0.095691574/speed),
                },

                new FollowStations
                {
                    numberStation1= 38880,
                    numberStation2= 38881,
                    distance = 0.098658406,
                    drivinngTime= TimeSpan.FromMinutes(0.098658406/speed),
                },

                new FollowStations
                {
                    numberStation1= 38881,
                    numberStation2= 38883,
                    distance = 0.010839727,
                    drivinngTime= TimeSpan.FromMinutes(0.010839727/speed),
                },

                new FollowStations
                {
                    numberStation1= 38883,
                    numberStation2= 38884,
                    distance = 0.0048824,
                    drivinngTime= TimeSpan.FromMinutes(0.0048824/speed),
                },

                new FollowStations
                {
                    numberStation1= 38884,
                    numberStation2= 38885,
                    distance = 0.002361177,
                    drivinngTime= TimeSpan.FromMinutes(0.002361177/speed),
                },

                new FollowStations
                {
                    numberStation1= 38885,
                    numberStation2= 38886,
                    distance = 0.002591482,
                    drivinngTime= TimeSpan.FromMinutes(0.002591482/speed),
                },

                new FollowStations
                {
                    numberStation1= 38886,
                    numberStation2= 38887,
                    distance = 0.002278754,
                    drivinngTime= TimeSpan.FromMinutes(0.002278754/speed),
                },

                new FollowStations
                {
                    numberStation1= 38887,
                    numberStation2= 38888,
                    distance = 0.00158888,
                    drivinngTime= TimeSpan.FromMinutes(0.00158888/speed),
                },

                new FollowStations
                {
                    numberStation1= 38888,
                    numberStation2= 38889,
                    distance = 0.012050884,
                    drivinngTime= TimeSpan.FromMinutes(0.012050884/speed),
                },

                new FollowStations
                {
                    numberStation1= 38889,
                    numberStation2= 38890,
                    distance = 0.002504912,
                    drivinngTime= TimeSpan.FromMinutes(0.002504912/speed),
                },

                new FollowStations
                {
                    numberStation1= 38884,
                    numberStation2= 38885,
                    distance = 0.002361177,
                    drivinngTime= TimeSpan.FromMinutes(0.002361177/speed),
                },

                new FollowStations
                {
                    numberStation1= 38885,
                    numberStation2= 38883,
                    distance = 0.006830095,
                    drivinngTime= TimeSpan.FromMinutes(0.006830095/speed),
                },

                new FollowStations
                {
                    numberStation1= 38883,
                    numberStation2= 38886,
                    distance = 0.008716686,
                    drivinngTime= TimeSpan.FromMinutes(0.008716686/speed),
                },

                new FollowStations
                {
                    numberStation1= 38886,
                    numberStation2= 38887,
                    distance = 0.002278754,
                    drivinngTime= TimeSpan.FromMinutes(0.002278754/speed),
                },

                new FollowStations
                {
                    numberStation1= 38887,
                    numberStation2= 38888,
                    distance = 0.00158888,
                    drivinngTime= TimeSpan.FromMinutes(0.00158888/speed),
                },

                new FollowStations
                {
                    numberStation1= 38888,
                    numberStation2= 38881,
                    distance = 0.004349328,
                    drivinngTime= TimeSpan.FromMinutes(0.004349328/speed),
                },

                new FollowStations
                {
                    numberStation1= 38881,
                    numberStation2= 38890,
                    distance = 0.008586347,
                    drivinngTime= TimeSpan.FromMinutes(0.008586347/speed),
                },

                new FollowStations
                {
                    numberStation1= 38890,
                    numberStation2= 38889,
                    distance = 0.002504912,
                    drivinngTime= TimeSpan.FromMinutes(0.002504912/speed),
                },

                new FollowStations
                {
                    numberStation1= 38889,
                    numberStation2= 38855,
                    distance = 0.058294652,
                    drivinngTime= TimeSpan.FromMinutes(0.058294652/speed),
                },

                new FollowStations
                {
                    numberStation1= 38838,
                    numberStation2= 38839,
                    distance = 0.005246485,
                    drivinngTime= TimeSpan.FromMinutes(0.005246485/speed),
                },

                new FollowStations
                {
                    numberStation1= 38838,
                    numberStation2= 38839,
                    distance = 0.005246485,
                    drivinngTime= TimeSpan.FromMinutes(0.005246485/speed),
                },

                new FollowStations
                {
                    numberStation1= 38839,
                    numberStation2= 38844,
                    distance = 0.005167764,
                    drivinngTime= TimeSpan.FromMinutes(0.005167764/speed),
                },

                new FollowStations
                {
                    numberStation1= 38844,
                    numberStation2= 38845,
                    distance = 0.001986142,
                    drivinngTime= TimeSpan.FromMinutes(0.001986142/speed),
                },

                new FollowStations
                {
                    numberStation1= 38845,
                    numberStation2= 38840,
                    distance = 0.006656221,
                    drivinngTime= TimeSpan.FromMinutes(0.006656221/speed),
                },

                new FollowStations
                {
                    numberStation1= 38840,
                    numberStation2= 38841,
                    distance = 0.00328286,
                    drivinngTime= TimeSpan.FromMinutes(0.00328286/speed),
                },

                new FollowStations
                {
                    numberStation1= 38841,
                    numberStation2= 38846,
                    distance = 0.008145975,
                    drivinngTime= TimeSpan.FromMinutes(0.008145975/speed),
                },

                new FollowStations
                {
                    numberStation1= 38846,
                    numberStation2= 38842,
                    distance = 0.008145975,
                    drivinngTime= TimeSpan.FromMinutes(0.008145975/speed),
                },

                new FollowStations
                {
                    numberStation1= 38842,
                    numberStation2= 38879,
                    distance = 0.04110075,
                    drivinngTime= TimeSpan.FromMinutes(0.04110075/speed),
                },

                new FollowStations
                {
                    numberStation1= 38879,
                    numberStation2= 38880,
                    distance = 0.005284236,
                    drivinngTime= TimeSpan.FromMinutes(0.005284236/speed),
                },

                new FollowStations
                {
                    numberStation1= 38856,
                    numberStation2= 38867,
                    distance = 0.010176574,
                    drivinngTime= TimeSpan.FromMinutes(0.010176574/speed),
                },

                new FollowStations
                {
                    numberStation1= 38867,
                    numberStation2= 38873,
                    distance = 0.011705368,
                    drivinngTime= TimeSpan.FromMinutes(0.011705368/speed),
                },

                new FollowStations
                {
                    numberStation1= 38873,
                    numberStation2= 38834,
                    distance = 0.016780379,
                    drivinngTime= TimeSpan.FromMinutes(0.016780379/speed),
                },

                new FollowStations
                {
                    numberStation1= 38834,
                    numberStation2= 38837,
                    distance = 0.006306611,
                    drivinngTime= TimeSpan.FromMinutes(0.006306611/speed),
                },

                new FollowStations
                {
                    numberStation1= 38837,
                    numberStation2= 38875,
                    distance = 0.021185537,
                    drivinngTime= TimeSpan.FromMinutes(0.021185537/speed),
                },

                new FollowStations
                {
                    numberStation1= 38875,
                    numberStation2= 38872,
                    distance = 0.041672295,
                    drivinngTime= TimeSpan.FromMinutes(0.041672295/speed),
                },

                new FollowStations
                {
                    numberStation1= 38872,
                    numberStation2= 38876,
                    distance = 0.048392316,
                    drivinngTime= TimeSpan.FromMinutes(0.048392316/speed),
                },

                new FollowStations
                {
                    numberStation1= 38876,
                    numberStation2= 38852,
                    distance = 0.02213966,
                    drivinngTime= TimeSpan.FromMinutes(0.02213966/speed),
                },

                new FollowStations
                {
                    numberStation1= 38852,
                    numberStation2= 38854,
                    distance = 0.057002492,
                    drivinngTime= TimeSpan.FromMinutes(0.057002492/speed),
                },

                new FollowStations
                {
                    numberStation1= 38854,
                    numberStation2= 38847,
                    distance = 0.073758262,
                    drivinngTime= TimeSpan.FromMinutes(0.073758262/speed),
                },

                new FollowStations
                {
                    numberStation1= 38847,
                    numberStation2= 38833,
                    distance = 0.020235053,
                    drivinngTime= TimeSpan.FromMinutes(0.020235053/speed),
                },

                new FollowStations
                {
                    numberStation1= 38833,
                    numberStation2= 38865,
                    distance = 0.114946041,
                    drivinngTime= TimeSpan.FromMinutes(0.114946041/speed),
                },

                new FollowStations
                {
                    numberStation1= 38865,
                    numberStation2= 38866,
                    distance = 0.019539281,
                    drivinngTime= TimeSpan.FromMinutes(0.019539281/speed),
                },

                new FollowStations
                {
                    numberStation1= 38866,
                    numberStation2= 38877,
                    distance = 0.08174347,
                    drivinngTime= TimeSpan.FromMinutes(0.08174347/speed),
                },

                new FollowStations
                {
                    numberStation1= 38877,
                    numberStation2= 38831,
                    distance = 0.108157927,
                    drivinngTime= TimeSpan.FromMinutes(0.108157927/speed),
                },

                new FollowStations
                {
                    numberStation1= 38864,
                    numberStation2= 38878,
                    distance = 0.059967716,
                    drivinngTime= TimeSpan.FromMinutes(0.059967716/speed),
                },

                new FollowStations
                {
                    numberStation1= 38832,
                    numberStation2= 38856,
                    distance = 0.008603002,
                    drivinngTime= TimeSpan.FromMinutes(0.008603002/speed),
                },

                new FollowStations
                {
                    numberStation1= 38856,
                    numberStation2= 38867,
                    distance = 0.010176574,
                    drivinngTime= TimeSpan.FromMinutes(0.010176574/speed),
                },

                new FollowStations
                {
                    numberStation1= 38867,
                    numberStation2= 38873,
                    distance = 0.011705368,
                    drivinngTime= TimeSpan.FromMinutes(0.011705368/speed),
                },

                new FollowStations
                {
                    numberStation1= 38873,
                    numberStation2= 38834,
                    distance = 0.016780379,
                    drivinngTime= TimeSpan.FromMinutes(0.016780379/speed),
                },

                new FollowStations
                {
                    numberStation1= 38834,
                    numberStation2= 38837,
                    distance = 0.006306611,
                    drivinngTime= TimeSpan.FromMinutes(0.006306611/speed),
                },

                new FollowStations
                {
                    numberStation1= 38837,
                    numberStation2= 38875,
                    distance = 0.021185537,
                    drivinngTime= TimeSpan.FromMinutes(0.021185537/speed),
                },

                new FollowStations
                {
                    numberStation1= 38875,
                    numberStation2= 38872,
                    distance = 0.041672295,
                    drivinngTime= TimeSpan.FromMinutes(0.041672295/speed),
                },

                new FollowStations
                {
                    numberStation1= 38872,
                    numberStation2= 38876,
                    distance = 0.048392316,
                    drivinngTime= TimeSpan.FromMinutes(0.048392316/speed),
                },

                new FollowStations
                {
                    numberStation1= 38876,
                    numberStation2= 38852,
                    distance = 0.02213966,
                    drivinngTime= TimeSpan.FromMinutes(0.02213966/speed),
                },

                new FollowStations
                {
                    numberStation1= 38831,
                    numberStation2= 38864,
                    distance = 0.11614573,
                    drivinngTime= TimeSpan.FromMinutes(0.11614573/speed),
                }
                #endregion
            };
            allLines = new List<LineBus>
            {
                #region restart 10 Line Bus
                new LineBus
                {
                    identifyBus = 1000,
                    numberLine = 277,
                    area = Area.center,
                    firstNumberStation = 38832,
                    lastNumberStation = 38855,
                    deleted = false
                },

                new LineBus
                {
                    identifyBus = 1001,
                    numberLine = 150,
                    area = Area.center,
                    firstNumberStation = 38834,
                    lastNumberStation = 38838,
                    deleted = false
                },

                new LineBus
                {
                    identifyBus = 1002,
                    numberLine = 111,
                    area = Area.general,
                    firstNumberStation = 38859,
                    lastNumberStation = 38869,
                    deleted = false
                },

                new LineBus
                {
                    identifyBus = 1003,
                    numberLine = 200,
                    area = Area.center,
                    firstNumberStation = 38846,
                    lastNumberStation = 38836,
                    deleted = false
                },

                new LineBus
                {
                    identifyBus = 1004,
                    numberLine = 220,
                    area = Area.center,
                    firstNumberStation = 38880,
                    lastNumberStation = 38890,
                    deleted = false
                },

                new LineBus
                {
                    identifyBus = 1005,
                    numberLine = 221,
                    area = Area.center,
                    firstNumberStation = 38884,
                    lastNumberStation = 38855,
                    deleted = false
                },

                new LineBus
                {
                    identifyBus = 1006,
                    numberLine = 230,
                    area = Area.center,
                    firstNumberStation = 38838,
                    lastNumberStation = 38880,
                    deleted = false
                },

                new LineBus
                {
                    identifyBus = 1007,
                    numberLine = 240,
                    area = Area.center,
                    firstNumberStation = 38832,
                    lastNumberStation = 38852,
                    deleted = false
                },

                new LineBus
                {
                    identifyBus = 1008,
                    numberLine = 510,
                    area = Area.center,
                    firstNumberStation = 38852,
                    lastNumberStation = 38878,
                    deleted = false
                },

                new LineBus
                {
                    identifyBus = 1009,
                    numberLine = 37,
                    area = Area.south,
                    firstNumberStation = 38832,
                    lastNumberStation = 38852,
                    deleted = false
                },

            };
            #endregion
            allExitLines = new List<ExitLine>
            {
                #region restart exit line
                new ExitLine
                {
                    identifyBus = 1000,
                    startTime = TimeSpan.Parse("08:00:05"),
                    frequency = 1,
                    endTime = TimeSpan.Parse("08:05:59")
                },
                new ExitLine
                {
                    identifyBus = 1000,
                    startTime = TimeSpan.Parse("11:00:00"),
                    frequency = 60,
                    endTime = TimeSpan.Parse("17:59:59")
                },
                new ExitLine
                {
                    identifyBus = 1000,
                    startTime = TimeSpan.Parse("18:00:00"),
                    frequency = 30,
                    endTime = TimeSpan.Parse("23:59:59")
                },
                new ExitLine
                {
                    identifyBus = 1001,
                    startTime = TimeSpan.Parse("08:00:00"),
                    frequency = 15,
                    endTime = TimeSpan.Parse("10:59:59")
                },
                new ExitLine
                {
                    identifyBus = 1001,
                    startTime = TimeSpan.Parse("11:00:00"),
                    frequency = 45,
                    endTime = TimeSpan.Parse("17:59:59")
                },
                new ExitLine
                {
                    identifyBus = 1001,
                    startTime = TimeSpan.Parse("18:00:00"),
                    frequency = 90,
                    endTime = TimeSpan.Parse("23:59:59")
                },
                new ExitLine
                {
                    identifyBus = 1002,
                    startTime = TimeSpan.Parse("08:00:00"),
                    frequency = 15,
                    endTime = TimeSpan.Parse("11:59:59")
                },
                new ExitLine
                {
                    identifyBus = 1002,
                    startTime = TimeSpan.Parse("12:00:00"),
                    frequency = 10,
                    endTime = TimeSpan.Parse("15:59:59")
                },
                new ExitLine
                {
                    identifyBus = 1002,
                    startTime = TimeSpan.Parse("16:00:00"),
                    frequency = 5,
                    endTime = TimeSpan.Parse("19:59:59")
                },
                new ExitLine
                {
                    identifyBus = 1002,
                    startTime = TimeSpan.Parse("20:00:00"),
                    frequency = 60,
                    endTime = TimeSpan.Parse("23:59:59")
                },
                new ExitLine
                {
                    identifyBus = 1003,
                    startTime = TimeSpan.Parse("08:00:00"),
                    frequency = 90,
                    endTime = TimeSpan.Parse("11:59:59")
                },
                new ExitLine
                {
                    identifyBus = 1003,
                    startTime = TimeSpan.Parse("12:00:00"),
                    frequency = 30,
                    endTime = TimeSpan.Parse("18:59:59")
                },
                new ExitLine
                {
                    identifyBus = 1003,
                    startTime = TimeSpan.Parse("19:00:00"),
                    frequency = 90,
                    endTime = TimeSpan.Parse("23:59:59")
                },
                new ExitLine
                {
                    identifyBus = 1004,
                    startTime = TimeSpan.Parse("08:00:00"),
                    frequency = 60,
                    endTime = TimeSpan.Parse("15:59:59")
                },
                new ExitLine
                {
                    identifyBus = 1004,
                    startTime = TimeSpan.Parse("16:00:00"),
                    frequency = 120,
                    endTime = TimeSpan.Parse("23:59:59")
                },
                #endregion
            };

            allUsers = new List<User>
            {
                new User
                {
                    name = "Renana Emanuel",
                    userName = "renana",
                    password = "renana",
                    mail = "renana12ema@gmail.com"
                },
                new User
                {
                    name = "Maayan Zohar",
                    userName = "maayan",
                    password = "maayan",
                    mail = "maayan659@gmail.com"
                }
            };
        }

    }
}
