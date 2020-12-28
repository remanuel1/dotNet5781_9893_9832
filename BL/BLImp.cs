using System;
using System.Collections.Generic;
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
            catch (DO.BusExceptions ex)
            {
                //throw new BO.BadStudentIdException("Student ID is illegal", ex);
            }
            busDO.CopyPropertiesTo(busBO);
            return busBO;
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
            catch (DO.BusExceptions ex)
            {
                //throw new BO.BadStudentIdException("Student ID is illegal", ex);
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
            catch (DO.BusStationExceptions ex)
            {
                //throw new BO.BusStationExceptions("Bus Station is illegal", ex);
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
            catch (DO.BusStationExceptions ex)
            {
                //throw new BO.BusStationExceptions("Bus Station is illegal", ex);
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
            catch (DO.BusStationExceptions ex)
            {
                //throw new BO.BusStationExceptions("Bus Station is illegal", ex);
            }
        }
        public BO.BusStation getBusStation(int numberStation)
        {
            DO.BusStation busStationDO = new DO.BusStation();
            try
            {
                busStationDO = dl.getBusStation(numberStation);
            }
            catch (DO.BusStationExceptions ex)
            {
                //throw new BO.BadStudentIdException("Person id does not exist or he is not a student", ex);
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
            catch (DO.BusExceptions ex)
            {
                //throw new BO.BadStudentIdException("Student ID is illegal", ex);
            }
            lineBusDO.CopyPropertiesTo(lineBusBO);
            return lineBusBO;
        }
        public void insertLineBus(BO.LineBus lineBus)
        {
            if (lineBus.listStaion.Count() < 2)
                //throw; 
                ;
            DO.LineBus lineBusDO = new DO.LineBus();
            lineBusDO.CopyPropertiesTo(lineBus);
            lineBusDO.firstNumberStation = lineBus.listStaion.First().numberStation;
            lineBusDO.lastNumberStation = lineBus.listStaion.Last().numberStation;
            try
            {
                dl.addLineBus(lineBusDO);
                for(int i=0; i<lineBus.listStaion.Count()-1; i++)
                {

                }
            }
            catch (DO.BusStationExceptions ex)
            {
                //throw new BO.BusStationExceptions("Bus Station is illegal", ex);
            }
        }
        public void updateLineBus(BO.LineBus lineBus)
        {
            if (lineBus.listStaion.Count() < 2)
                //throw; 
                ;
            DO.LineBus lineBusDO = new DO.LineBus();
            lineBusDO.CopyPropertiesTo(lineBus);
            try
            {
                dl.updateLineBus(lineBusDO);
            }
            catch (DO.BusStationExceptions ex)
            {
                //throw new BO.BusStationExceptions("Bus Station is illegal", ex);
            }
        }
        public void deleteLineBus(BO.LineBus lineBus)
        {
            DO.LineBus lineBusDO = new DO.LineBus();
            lineBusDO.CopyPropertiesTo(lineBus);
            try
            {
                dl.updateLineBus(lineBusDO);
            }
            catch (DO.BusStationExceptions ex)
            {
                //throw new BO.BusStationExceptions("Bus Station is illegal", ex);
            }
        }
        public BO.LineBus getLineBus(int identifyBus)
        {
            DO.LineBus lineBusDO = new DO.LineBus();
            try
            {
                lineBusDO = dl.getLineBus(identifyBus);
            }
            catch (DO.BusStationExceptions ex)
            {
                //throw new BO.BadStudentIdException("Person id does not exist or he is not a student", ex);
            }
            return lineBusDoBoAdapter(lineBusDO);
        }
        public IEnumerable<BO.LineBus> getAllLineBus()
        {
            return from item in dl.getAllLineBus()
                   select lineBusDoBoAdapter(item);
        }

        #endregion
    }
}
