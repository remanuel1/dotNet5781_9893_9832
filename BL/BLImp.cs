using System;
using System.Collections.Generic;
using System.Device.Location;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLAPI;
using DLAPI;

namespace BL
{
    class BLImp : IBL
    {
        IDL dl = DLFactory.GetDal();

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
            if (bus.startActivity.Year < 2018 && bus.numberLicense.Length > 7)
                throw new BO.BadIDAndDateExceptions(int.Parse(bus.numberLicense), bus.startActivity, "number License not math to this date");
            if (bus.startActivity.Year >= 2018 && bus.numberLicense.Length <= 7)
                throw new BO.BadIDAndDateExceptions(int.Parse(bus.numberLicense), bus.startActivity, "number License not math to this date");
            if (DateTime.Now < bus.startActivity)
                throw new BO.BadDateExceptions(bus.startActivity, "date is illegal");
            DO.Bus busDO = new DO.Bus();
            busDO.CopyPropertiesTo(bus);
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
            if (DateTime.Now < bus.startActivity)
                throw new BO.BadDateExceptions(bus.startActivity, "date is illegal");

            DO.Bus busDO = new DO.Bus();
            busDO.CopyPropertiesTo(bus);
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
            busDO.CopyPropertiesTo(bus);
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
            return from item in dl.getAllBusses()
                   orderby item.startActivity
                   select busDoBoAdapter(item);
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
            return busStationBO;
        }
        public void insertBusStation(BO.BusStation busStation)
        {
            DO.BusStation busStationDO = new DO.BusStation();
            busStationDO.CopyPropertiesTo(busStation);
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
            busStationDO.CopyPropertiesTo(busStation);
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
            busStationDO.CopyPropertiesTo(busStation);
            try
            {
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
            return from item in dl.getAllBusStation()
                   orderby item.numberStation
                   select busStationDoBoAdapter(item);
        }
        #endregion

        #region DRIVIND
        /*
         * מימוש
         */
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
            return lineBusBO;
        }
        public void insertLineBus(BO.LineBus lineBus)
        {
            if (lineBus.listStaion.Count() < 2)
                throw new BO.BadLineExceptions("to add line, need 2 bus station"); 

            DO.LineBus lineBusDO = new DO.LineBus();
            lineBusDO.CopyPropertiesTo(lineBus);
            lineBusDO.firstNumberStation = lineBus.listStaion.First().numberStation;
            lineBusDO.lastNumberStation = lineBus.listStaion.Last().numberStation;
            try
            {
                dl.addLineBus(lineBusDO);
                for(int i=0; i<lineBus.listStaion.Count()-1; i++)
                {
                    BO.BusStation first = busStationDoBoAdapter(dl.getBusStation(lineBus.listStaion.ElementAt(i).numberStation));
                    BO.BusStation second = busStationDoBoAdapter(dl.getBusStation(lineBus.listStaion.ElementAt(i+1).numberStation)); 
                    insertFollowStations(first, second);
                }
            }
            catch (DO.BadIdException ex)
            {
                throw new BO.BadIDExceptions("this line bus exsit", ex);
            }
        }
        public void updateLineBus(BO.LineBus lineBus)
        {
            if (lineBus.listStaion.Count() < 2)
                throw new BO.BadLineExceptions("to add line, need 2 bus station");

            DO.LineBus lineBusDO = new DO.LineBus();
            lineBusDO.CopyPropertiesTo(lineBus);
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
            lineBusDO.CopyPropertiesTo(lineBus);
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
            return from item in dl.getAllLineBus()
                   select lineBusDoBoAdapter(item);
        }
        public IEnumerable<BO.BusStation> getStationInLineBus(BO.LineBus lineBus)
        {
            return from item in lineBus.listStaion
                   orderby item.numberStationInLine
                   select busStationDoBoAdapter(dl.getBusStation(item.numberStation));
        }
        public void addStationtoLine(BO.LineBus line, BO.BusStation station, int indexInLine)
        {
            if (indexInLine < 1 || indexInLine > line.listStaion.Count() + 1)
                throw new BO.BadIDExceptions("index to insert station is illegal");
            BO.LineStation newLineStation = new BO.LineStation();
            newLineStation.identifyBus = line.identifyBus;
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

            foreach (BO.LineStation item in line.listStaion)
            {
                if (item.numberStationInLine >= indexInLine)
                    item.numberStationInLine++;
            }

            line.listStaion.ToList().Insert(indexInLine - 1, newLineStation);

            try
            {
                foreach(BO.LineStation item in line.listStaion)
                {
                    if(item.numberStationInLine>indexInLine) //station that change
                        updateLineStation(item);
                }
            }
            catch (DO.BadIdException ex)
            {
                throw new BO.BadIDExceptions("this line station not exist", ex);
            }
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
        public void insertFollowStations(BO.BusStation station1, BO.BusStation station2)
        {
            try
            {
                dl.getBusStation(station1.numberStation);
                dl.getBusStation(station2.numberStation);
            }
            catch (DO.BadIdException ex)
            {
                throw new BO.BadIDExceptions($"station number: {ex.ID} not found", ex);
            }
            DO.FollowStations follow = new DO.FollowStations();
            follow.numberStation1 = station1.numberStation;
            follow.numberStation2 = station2.numberStation;

            var s1 = new GeoCoordinate(station1.Latitude, station1.Longitude);
            var d1 = new GeoCoordinate(station2.Latitude, station2.Longitude);
            follow.distance = s1.GetDistanceTo(d1);
            follow.drivinngTime = TimeSpan.FromSeconds(follow.distance / 50);
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
        //void updateFollowStations(FollowStations stations);
        //void deleteFollowStations(FollowStations stations);
        //IEnumerable<FollowStations> getAllFollowStations();

        #endregion

        #region Line Station
        BO.LineStation lineStationDoBoAdapter(DO.LineStation lineStationDO)
        {
            BO.LineStation lineStationBO = new BO.LineStation();
            int id = lineStationDO.numberStation;
            try
            {
                lineStationDO = dl.getLineStation(id);
            }
            catch (DO.BadIdException ex)
            {
                throw new BO.BadIDExceptions("this line station not exists", ex);
            }
            lineStationDO.CopyPropertiesTo(lineStationBO);
            return lineStationBO;
        }
        public void insertLineStation(BO.LineStation lineStation)
        {
            DO.LineStation lineStationDO = new DO.LineStation();
            lineStationDO.CopyPropertiesTo(lineStation);
            try
            {
                dl.addLineStation(lineStationDO);
            }
            catch (DO.BadIdException ex)
            {
                throw new BO.BadIDExceptions("this line station is exists", ex);
            }
        }
        public void updateLineStation(BO.LineStation lineStation)
        {
            DO.LineStation lineStationDO = new DO.LineStation();
            lineStationDO.CopyPropertiesTo(lineStation);
            try
            {
                dl.updateLineStation(lineStationDO);
            }
            catch (DO.BadIdException ex)
            {
                throw new BO.BadIDExceptions("this line station not found", ex);
            }
        }
        public void deleteLineStation(BO.LineStation lineStation)
        {
            DO.LineStation lineStationDO = new DO.LineStation();
            lineStationDO.CopyPropertiesTo(lineStation);
            try
            {
                dl.deleteLineStation(lineStationDO);
            }
            catch (DO.BadIdException ex)
            {
                throw new BO.BadIDExceptions("this line station not exists", ex);
            }
        }
        public IEnumerable<BO.LineStation> getAllLineStation()
        {
            return from item in dl.getAllLineStation()
                   select lineStationDoBoAdapter(item);
        }
        #endregion
    }
}
