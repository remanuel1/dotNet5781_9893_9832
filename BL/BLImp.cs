using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.ComponentModel;
using BLAPI;
using DLAPI;
using System.Device.Location;

namespace BL
{
    class BLImp : IBL
    {
        IDL dl = DLFactory.GetDal();

        #region singelton
        static readonly BLImp instance = new BLImp();
        static BLImp() { }// static ctor to ensure instance init is done just before first usage
        BLImp() { } // default => private
        public static BLImp Instance { get => instance; }// The public Instance property to use
        #endregion


        #region BUS - BONUS
        BO.Bus busDoBoAdapter(DO.Bus busDO)
        {
            
            BO.Bus busBO = new BO.Bus();
            string id = busDO.numberLicense;
            try
            {
                busDO = dl.getBus(id);
            }
            catch (DO.BadIdException ex)
            {
                throw new BO.BadIDExceptions("this bus is not found", ex);
            }
            busDO.CopyPropertiesTo(busBO);
            return busBO;
        }
        public void insertBus(BO.Bus bus)
        {
            if (bus.startActivity.Year < 2018 && bus.numberLicense.Length > 7 || bus.numberLicense.Length <7)
                throw new BO.BadIDAndDateExceptions(int.Parse(bus.numberLicense), bus.startActivity, "number License not math to this date");
            if (bus.startActivity.Year >= 2018 && bus.numberLicense.Length <= 7)
                throw new BO.BadIDAndDateExceptions(int.Parse(bus.numberLicense), bus.startActivity, "number License not math to this date");
            if (DateTime.Now < bus.startActivity || DateTime.Now < bus.lastTreat)
                throw new BO.BadDateExceptions(bus.startActivity, "date is illegal");
            DO.Bus busDO = new DO.Bus();
            bus.CopyPropertiesTo(busDO);
            try
            {
                dl.addBus(busDO);
            }
            catch (DO.BadIdException ex)
            {
                throw new BO.BadIDExceptions("bus is exist", ex);
            }
        }
        public void updateBus(BO.Bus bus)
        {
            if (bus.startActivity.Year < 2018 && bus.numberLicense.Length > 7)
                throw new BO.BadIDAndDateExceptions(int.Parse(bus.numberLicense), bus.startActivity, "number License not math to this date");
            if (bus.startActivity.Year >= 2018 && bus.numberLicense.Length <= 7)
                throw new BO.BadIDAndDateExceptions(int.Parse(bus.numberLicense), bus.startActivity, "number License not math to this date");
            if (DateTime.Now < bus.startActivity || DateTime.Now < bus.lastTreat)
                throw new BO.BadDateExceptions(bus.startActivity, "date is illegal");
            DO.Bus busDO = new DO.Bus();
            bus.CopyPropertiesTo(busDO);
            try
            {
                dl.updateBus(busDO);
            }
            catch (DO.BadIdException ex)
            {
                throw new BO.BadIDExceptions("this bus is not found", ex);
            }
        }
        public void deleteBus(BO.Bus bus)
        {
            if (bus.startActivity.Year < 2018 && bus.numberLicense.Length > 7)
                throw new BO.BadIDAndDateExceptions(int.Parse(bus.numberLicense), bus.startActivity, "number License not math to this date");
            if (bus.startActivity.Year >= 2018 && bus.numberLicense.Length <= 7)
                throw new BO.BadIDAndDateExceptions(int.Parse(bus.numberLicense), bus.startActivity, "number License not math to this date");
            if (DateTime.Now < bus.startActivity)
                throw new BO.BadDateExceptions(bus.startActivity, "date is illegal");

            DO.Bus busDO = new DO.Bus();
            bus.CopyPropertiesTo(busDO);
            try
            {
                dl.deleteBus(busDO);
            }
            catch (DO.BadIdException ex)
            {
                throw new BO.BadIDExceptions("this bus is not found", ex);
            }
        }
        public BO.Bus getBus(string numberLicense)
        {
            DO.Bus busDO = new DO.Bus();
            try
            {
                busDO = dl.getBus(numberLicense);
            }
            catch (DO.BadIdException ex)
            {
                throw new BO.BadIDExceptions("this bus is not found", ex);
            }
            return busDoBoAdapter(busDO);
        }
        public IEnumerable<BO.Bus> getAllBusses()
        {
            return (from item in dl.getAllBusses()
                   orderby item.startActivity
                   select busDoBoAdapter(item)).ToList();
        }

        public IEnumerable<BO.Bus> getAllBussesBy(IOrderedEnumerable<string> elements)
        {
            return (from item in dl.getAllBusses()
                    orderby elements
                    select busDoBoAdapter(item)).ToList();
        }

        public void refuel(BO.Bus bus)
        {
            bus.totalFuel = 1200;
            updateBus(bus);
        }
        public void treat(BO.Bus bus)
        {
            bus.lastTreat = DateTime.Now;
            bus.sumKMFromLastTreat = 0;
            bus.Status = BO.Status.ready;
            updateBus(bus);
        }

        #endregion

        #region BUS STATION
        BO.BusStation busStationDoBoAdapter(DO.BusStation busStationDO)
        {
            BO.BusStation busStationBO = new BO.BusStation();
            int id = busStationDO.numberStation;
            try
            {
                busStationDO = dl.getBusStation(id);
            }
            catch (DO.BadIdException ex)
            {
                throw new BO.BadIDExceptions("this bus station not found", ex);
            }
            busStationDO.CopyPropertiesTo(busStationBO);
            busStationBO.lineInStation = convertLineStationDoBo(dl.getLineStationInStation(id));
            return busStationBO;
        }
        public void insertBusStation(BO.BusStation busStation)
        {
            DO.BusStation busStationDO = new DO.BusStation();
            if (busStation.Latitude < 33.7 || busStation.Latitude > 36.3 || busStation.Longitude < 29.3 || busStation.Longitude > 33.5)
                throw new BO.BadLocalExceptions("this location is out from ISRAEL");
            busStation.CopyPropertiesTo(busStationDO);
            try
            {
                dl.addBusStation(busStationDO);
            }
            catch (DO.BadIdException ex)
            {
                throw new BO.BadIDExceptions("this bus station is exist", ex);
            }
            
        }
        public void updateBusStation(BO.BusStation busStation)
        {
            DO.BusStation busStationDO = new DO.BusStation();
            if (busStation.Latitude < 33.7 || busStation.Latitude > 36.3 || busStation.Longitude < 29.3 || busStation.Longitude > 33.5)
                throw new BO.BadLocalExceptions("this location is out from ISRAEL");
            busStation.CopyPropertiesTo(busStationDO);
            try
            {
                dl.updateBusStation(busStationDO);
            }
            catch (DO.BadIdException ex)
            {
                throw new BO.BadIDExceptions("this bus station not found", ex);
            }
        }
        public void deleteBusStation(BO.BusStation busStation)
        {
            DO.BusStation busStationDO = new DO.BusStation();
            busStation.CopyPropertiesTo(busStationDO);
            try
            {
                foreach(BO.LineStation station in busStation.lineInStation)
                {
                    BO.LineBus line = getLineBus(station.identifyLine);
                    deleteStationInLine(line, station);
                }
                dl.deleteBusStation(busStationDO);
            }
            catch (DO.BadIdException ex)
            {
                throw new BO.BadIDExceptions("this bus station not found", ex);
            }
        }
        public BO.BusStation getBusStation(int numberStation)
        {
            DO.BusStation busStationDO = new DO.BusStation();
            try
            {
                busStationDO = dl.getBusStation(numberStation);
            }
            catch (DO.BadIdException ex)
            {
                throw new BO.BadIDExceptions("this bus station not found", ex);
            }
            return busStationDoBoAdapter(busStationDO);
        }
        public IEnumerable<BO.BusStation> getAllBusStations()
        {
            return (from item in dl.getAllBusStation()
                   orderby item.numberStation
                   select busStationDoBoAdapter(item)).ToList();
        }

        public IEnumerable<int> getLineInBusStations(BO.BusStation station)
        {
            return (from item in station.lineInStation
                    let line = dl.getLineBus(item.identifyLine)
                    orderby line.numberLine
                    select line.numberLine);
        }

        #endregion


        #region LineBus
        BO.LineBus lineBusDoBoAdapter(DO.LineBus lineBusDO)
        {
            BO.LineBus lineBusBO = new BO.LineBus();
            int id = lineBusDO.identifyBus;
            try
            {
                lineBusDO = dl.getLineBus(id);
            }
            catch (DO.BadIdException ex)
            {
                throw new BO.BadIDExceptions("this line bus not exsist", ex);
            }
            lineBusDO.CopyPropertiesTo(lineBusBO);
            IEnumerable<DO.LineStation> station = dl.getAllLineStationBy(l => l.identifyLine == lineBusBO.identifyBus);
            lineBusBO.listStaion = (from DO.LineStation item in station
                                   orderby item.numberStationInLine
                                   select lineStationDoBoAdapter(item)).ToList();
            return lineBusBO;
        }

        public int insertLineBus(BO.LineBus lineBus)
        {
            int id;
            if (lineBus.listStaion.Count() < 2)
                throw new BO.BadLineExceptions("to add line, need 2 bus station"); 

            DO.LineBus lineBusDO = new DO.LineBus();
            lineBus.CopyPropertiesTo(lineBusDO);
            lineBusDO.firstNumberStation = lineBus.listStaion.First().numberStation;
            lineBusDO.lastNumberStation = lineBus.listStaion.Last().numberStation;
            try
            {
                id = dl.addLineBus(lineBusDO);
                for(int i=0; i<lineBus.listStaion.Count()-1; i++)
                {
                    int first = lineBus.listStaion.ElementAt(i).numberStation;
                    int second = lineBus.listStaion.ElementAt(i + 1).numberStation;
                    try
                    {
                        insertFollowStations(first, second);
                    }
                    catch (DO.BadIdException ex)
                    {;}
                }
            }
            catch (DO.BadIdException ex)
            {
                throw new BO.BadIDExceptions("this line bus exsit", ex);
            }
            return id;
        }
        public void updateLineBus(BO.LineBus lineBus)
        {
            if (lineBus.listStaion.Count() < 2)
                throw new BO.BadLineExceptions("to add line, need 2 bus station");

            DO.LineBus lineBusDO = new DO.LineBus();
            lineBus.CopyPropertiesTo(lineBusDO);
            lineBusDO.firstNumberStation = lineBus.listStaion.First().numberStation;
            lineBusDO.lastNumberStation = lineBus.listStaion.Last().numberStation;
            try
            {
                dl.updateLineBus(lineBusDO);
            }
            catch (DO.BadIdException ex)
            {
                throw new BO.BadIDExceptions("this line bus not found", ex);
            }
        }
        public void deleteLineBus(BO.LineBus lineBus)
        {
            DO.LineBus lineBusDO = new DO.LineBus();
            lineBus.CopyPropertiesTo(lineBusDO);
            try
            {
                dl.deleteLineBus(lineBusDO);
                foreach (BO.LineStation item in lineBus.listStaion)
                    deleteLineStation(item);
            }
            catch (DO.BadIdException ex)
            {
                throw new BO.BadIDExceptions("this line bus not found", ex);
            }
        }
        public BO.LineBus getLineBus(int identifyBus)
        {
            DO.LineBus lineBusDO = new DO.LineBus();
            try
            {
                lineBusDO = dl.getLineBus(identifyBus);
            }
            catch (DO.BadIdException ex)
            {
                throw new BO.BadIDExceptions("this line bus not exist", ex);
            }
            return lineBusDoBoAdapter(lineBusDO);
        }
        public IEnumerable<BO.LineBus> getAllLineBus()
        {
            return (from item in dl.getAllLineBus()
                    orderby item.numberLine
                    select lineBusDoBoAdapter(item)).ToList();
        }

        public IEnumerable<IGrouping<BO.Area, BO.LineBus>> getAllLineBusByArea()
        {
            var listByArea = from line in getAllLineBus()
                             group line by line.area into g
                             select g;
            return listByArea;
        }

        public IEnumerable<BO.BusStation> getStationInLineBus(BO.LineBus lineBus)
        {
            return (from item in lineBus.listStaion
                   orderby item.numberStationInLine
                   select busStationDoBoAdapter(dl.getBusStation(item.numberStation))).ToList();
        }
        public void addStationToLine(BO.LineBus line, BO.BusStation station, int indexInLine)
        {
            //this func is to add station to exists line

            if (indexInLine < 1 || indexInLine > line.listStaion.Count() + 1) //check if index is legal
                throw new BO.BadIDExceptions("index to insert station is illegal");
            BO.LineStation newLineStation = new BO.LineStation();
            newLineStation.identifyLine = line.identifyBus;
            newLineStation.numberStation = station.numberStation;
            newLineStation.numberStationInLine = indexInLine;
            newLineStation.deleted = false;
            try
            {
                insertLineStation(newLineStation);
            }

            catch (DO.BadIdException ex)
            {
                throw new BO.BadIDExceptions("this line bus not exists", ex);
            }

            foreach (BO.LineStation item in line.listStaion) //change stations after this station with new place in line
            {
                if (item.numberStationInLine >= indexInLine)
                    item.numberStationInLine++;
            }
            try
            {
                foreach(BO.LineStation item in line.listStaion)
                {
                    if(item.numberStationInLine>indexInLine) //station that change
                        updateLineStation(item, item); //update all station after this station with new place in line
                }
            }
            catch (DO.BadIdException ex)
            {
                throw new BO.BadIDExceptions("this line station not exist", ex);
            }
            IEnumerable<DO.LineStation> stationList = dl.getAllLineStationBy(l => l.identifyLine == line.identifyBus);
            if (indexInLine !=1)
                insertFollowStations(station.numberStation, line.listStaion.ElementAt(indexInLine - 2).numberStation); //new follow with perior station
            if(indexInLine <= line.listStaion.Count())
                insertFollowStations(station.numberStation, line.listStaion.ElementAt(indexInLine-1).numberStation); //new follow with next station

            line.listStaion = (from DO.LineStation item in stationList
                               select lineStationDoBoAdapter(item)).ToList();
        }

        public void deleteStationInLine(BO.LineBus line, BO.LineStation station)
        {
            //this func is to delete station from exists line

            if (line.listStaion.Count() <= 2) //check if it is legal
                throw new BO.BadLineExceptions("impossible to deletete this station");
            try
            {
                if(line.listStaion.Count() == station.numberStationInLine)
                {
                    DO.LineBus lineBusDO = new DO.LineBus();
                    line.CopyPropertiesTo(lineBusDO);
                    lineBusDO.firstNumberStation = line.listStaion.ElementAt(0).numberStation;
                    lineBusDO.lastNumberStation = line.listStaion.ElementAt(station.numberStationInLine - 2).numberStation;
                    dl.updateLineBus(lineBusDO);
                    
                }
                deleteLineStation(station);
                foreach (BO.LineStation item in line.listStaion) //change stations after this station with new place in line
                {
                    if (item.numberStationInLine > station.numberStationInLine)
                    {
                        item.numberStationInLine--;
                        updateLineStation(item, item); //update all station after this station with new place in line
                    }

                }
            }
            catch (DO.BadIdException ex)
            {
                throw new BO.BadIDExceptions("this line station not exist", ex);
            }

            IEnumerable<DO.LineStation> stationList = dl.getAllLineStationBy(l => l.identifyLine == line.identifyBus);

            if (station.numberStationInLine != line.listStaion.Count() && station.numberStationInLine != 1) // check if need to insert follow station
            {
                int one = line.listStaion.ElementAt(station.numberStationInLine - 2).numberStation;
                int two = line.listStaion.ElementAt(station.numberStationInLine).numberStation;
                insertFollowStations(one, two);

            }
            line.listStaion = (from DO.LineStation item in stationList
                               select lineStationDoBoAdapter(item)).ToList();

            
        }

        #endregion

        #region Follow Stations
        BO.FollowStations FollowStationsDoBoAdapter(DO.FollowStations stations)
        {
            BO.FollowStations followStationsBO = new BO.FollowStations();
            int id1 = stations.numberStation1;
            int id2 = stations.numberStation2;
            try
            {
                stations = dl.getFollowStations(id1, id2);
            }
            catch (DO.BadTwoIdException ex)
            {

                throw new BO.BadIDExceptions($"station number: {ex.ID1} or {ex.ID2} not found", ex);
            }
            stations.CopyPropertiesTo(followStationsBO);
            return followStationsBO;
        }
        public void insertFollowStations(int station1, int station2)
        {
            try
            {
                dl.getBusStation(station1);
                dl.getBusStation(station2);
            }
            catch (DO.BadIdException ex)
            {
                throw new BO.BadIDExceptions($"station number: {ex.ID} not found", ex);
            }
            DO.FollowStations follow = new DO.FollowStations();
            follow.numberStation1 = station1;
            follow.numberStation2 = station2;

            GeoCoordinate s1 = new GeoCoordinate(dl.getBusStation(station1).Longitude, dl.getBusStation(station1).Latitude);
            GeoCoordinate d1 = new GeoCoordinate(dl.getBusStation(station2).Longitude, dl.getBusStation(station2).Latitude);
            follow.distance = s1.GetDistanceTo(d1);
            follow.drivinngTime = TimeSpan.FromMinutes(follow.distance/1000 * (60/50));
            follow.drivinngTime = TimeSpan.Parse(follow.drivinngTime.ToString().Substring(0, 8));
            follow.deleted = false;
            try
            {
                dl.addFollowStations(follow);
            }
            catch (DO.BadTwoIdException ex)
            {
                throw new BO.BadIDExceptions($"station number: {ex.ID1}, {ex.ID2} is exsits", ex);
            }
            
        }
        public BO.FollowStations getFollowStations(int station1, int station2)
        {
            DO.FollowStations followStationsDO = new DO.FollowStations();
            try
            {
                followStationsDO = dl.getFollowStations(station1, station2);
            }
            catch (DO.BadIdException ex)
            {
                throw new BO.BadIDExceptions("this follow stations not exist", ex);
            }
            return FollowStationsDoBoAdapter(followStationsDO);
        }

        #endregion

        #region Line Station
        BO.LineStation lineStationDoBoAdapter(DO.LineStation lineStationDO)
        {
            BO.LineStation lineStationBO = new BO.LineStation();
            int id = lineStationDO.numberStation;
            try
            {
                lineStationDO = dl.getLineStation(id, lineStationDO.identifyLine);
            }
            catch (DO.BadIdException ex)
            {
                throw new BO.BadIDExceptions("this line station not exists", ex);
            }
            lineStationDO.CopyPropertiesTo(lineStationBO);
            if (lineStationBO.numberStationInLine == 1)
                lineStationBO.timeFromPriorStation = TimeSpan.Zero;
            else
            {
                int numberPriorStation = dl.getLineStationIndex(lineStationBO.identifyLine, lineStationBO.numberStationInLine - 1).numberStation;
                lineStationBO.timeFromPriorStation = getFollowStations(numberPriorStation, lineStationBO.numberStation).drivinngTime;
            }
            lineStationBO.nameStation = dl.getBusStation(lineStationBO.numberStation).nameStation;
            return lineStationBO;
        }

        IEnumerable<BO.LineStation> convertLineStationDoBo(IEnumerable<DO.LineStation> lineStationDO)
        {
            return (from item in lineStationDO
                    select lineStationDoBoAdapter(item)).ToList();
        }
        public void insertLineStation(BO.LineStation lineStation)
        {
            DO.LineStation lineStationDO = new DO.LineStation();
            lineStation.CopyPropertiesTo(lineStationDO);
            try
            {
                dl.addLineStation(lineStationDO);
            }
            catch (DO.BadIdException ex)
            {
                throw new BO.BadIDExceptions("this line station is exists", ex);
            }
        }
        public void updateLineStation(BO.LineStation lineStationCurrent, BO.LineStation lineStationNew)
        {
            DO.LineStation lineStationCurrentDO = new DO.LineStation();
            DO.LineStation lineStationNewDO = new DO.LineStation();
            lineStationCurrent.CopyPropertiesTo(lineStationCurrentDO);
            lineStationNew.CopyPropertiesTo(lineStationNewDO);
            try
            {
                dl.updateLineStation(lineStationCurrentDO, lineStationNewDO);
            }
            catch (DO.BadIdException ex)
            {
                throw new BO.BadIDExceptions("this line station not found", ex);
            }
        }
        public void deleteLineStation(BO.LineStation lineStation)
        {
            DO.LineStation lineStationDO = new DO.LineStation();
            lineStation.CopyPropertiesTo(lineStationDO);
            try
            {
                dl.deleteLineStation(lineStationDO);
            }
            catch (DO.BadIdException ex)
            {
                throw new BO.BadIDExceptions("this line station not exists", ex);
            }
        }
        public BO.LineStation getLineStation(int identifyBus, int numberStation)
        {
            DO.LineStation lineStationDO = new DO.LineStation();
            try
            {
                lineStationDO = dl.getLineStation(numberStation, identifyBus);
            }
            catch (DO.BadIdException ex)
            {
                throw new BO.BadIDExceptions("this line bus not exist", ex);
            }
            return lineStationDoBoAdapter(lineStationDO);
        }
        public IEnumerable<BO.LineStation> getAllLineStation()
        {
            return (from item in dl.getAllLineStation()
                   select lineStationDoBoAdapter(item)).ToList();
        }
        
        public IEnumerable<BO.LineStation> getLineStationsForLine(int identifyBus)
        {
            return (from item in dl.getAllLineStation()
                    where item.identifyLine == identifyBus && item.deleted == false
                    orderby item.numberStationInLine
                    select lineStationDoBoAdapter(item)).ToList();
        }
        #endregion

        #region LineTiming
        public IEnumerable<BO.LineTiming> GetLineTimingsForStation(int numberStation, TimeSpan time)
        {
            // this func is to find all line timing in specific station and time
            List<BO.LineTiming> lineTimings = new List<BO.LineTiming>();
            IEnumerable<DO.LineStation> stations = dl.getAllLineStationBy(p => p.numberStation == numberStation); //get all line station with same number station to get all line in this station

            foreach (DO.LineStation item in stations) // foreach that pass over all line in this stations
            {
                IEnumerable<DO.ExitLine> exitLines = dl.getAllExitLineBy(item.identifyLine); // get all exit line according line
                foreach(DO.ExitLine exitLine in exitLines) // foreach that pass over all exit line
                {
                    TimeSpan exitTime = exitLine.startTime;
                    while(exitTime <= exitLine.endTime) //add new line trip while the exit time smaller than end time
                    {
                        BO.LineTiming lineTimingBO = new BO.LineTiming();
                        lineTimingBO.LineId = item.identifyLine;
                        lineTimingBO.LineNumber = dl.getLineBus(item.identifyLine).numberLine;
                        lineTimingBO.LastStation = dl.getBusStation(dl.getLineBus(item.identifyLine).lastNumberStation).nameStation;
                        lineTimingBO.TripStart = TimeSpan.Parse(exitTime.ToString());
                        lineTimingBO.ExpectedTimeTillArrive = exitTime + timeFromStartStation(item.identifyLine, numberStation) - time;
                        lineTimingBO.ExpectedTimeTillArrive = TimeSpan.Parse(lineTimingBO.ExpectedTimeTillArrive.ToString().Substring(0, 8));
                        exitTime += TimeSpan.FromMinutes(exitLine.frequency);
                        if(lineTimingBO.ExpectedTimeTillArrive + lineTimingBO.TripStart >= time)
                        {
                            lineTimings.Add(lineTimingBO); // if this ExpectedTimeTillArrive not over
                        }
                    }
                }
            }
            return lineTimings.OrderBy(t=> t.ExpectedTimeTillArrive);
        }

        private TimeSpan timeFromStartStation(int identifyLine, int numberStation)
        {
            // this func is calculating for station the time driving from first station

            BO.LineBus line = getLineBus(identifyLine);
            TimeSpan time = TimeSpan.Zero;
            if (getLineStation(identifyLine, numberStation) != null)
            {
                foreach (BO.LineStation item in line.listStaion)
                {
                    time += item.timeFromPriorStation;
                    if (item.numberStation == numberStation)
                        break;
                }
            }
            return time;
        }
        #endregion

        #region User
        public void addUser(BO.User user)
        {
            DO.User userToAdd = new DO.User();
            user.CopyPropertiesTo(userToAdd);
            try
            {
                dl.addUser(userToAdd);
            }
            catch
            {
                ;
            }
        }
        public void deleteUser(BO.User user)
        {
            DO.User userToDelete = new DO.User();
            user.CopyPropertiesTo(userToDelete);
            try
            {
                dl.deleteUser(userToDelete);
            }
            catch
            {
                ;
            }
        }
        public void updateUser(BO.User userCurrent, BO.User userNew)
        {
            DO.User userCDO = new DO.User();
            DO.User userNDO = new DO.User();
            userCurrent.CopyPropertiesTo(userCDO);
            userNew.CopyPropertiesTo(userNDO);
            try
            {
                dl.updateUser(userCDO, userNDO);
            }
            catch
            {
                ;
            }
        }
        public BO.User getUser(string userName)
        {
            BO.User user = new BO.User();
            try
            {
                dl.getUser(userName).CopyPropertiesTo(user);
            }
            catch
            {
                ;
            }
            return user;

        }

        public BO.User getUserByMail(string userMail)
        {
            BO.User user = new BO.User();
            try
            {
                dl.getUserByMail(userMail).CopyPropertiesTo(user);
            }
            catch
            {
                ;
            }
            return user;
        }
        public IEnumerable<object> getAllUser()
        {
            return from item in dl.getAllUser()
                   select new { type = item.type, name = item.name, userName = item.userName };
        }
        #endregion
    }
}
