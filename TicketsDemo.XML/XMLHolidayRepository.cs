using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicketsDemo.Data.Entities;
using TicketsDemo.Data.Repositories;
using System.Xml;
using System.Xml.Linq;
using System.Xml.Serialization;
using System.IO;
using TicketsDemo.Domain.Interfaces;
using TicketsDemo.Domain.DefaultImplementations;

namespace TicketsDemo.XML
{
    public class XMLHolidayRepository : IHolidayRepository
    {
       private IXMLService _service;
        public XMLHolidayRepository(IXMLService xmlServ)
        {
            _service = xmlServ;
        }
        public List<Holiday> GetAllHolidays()
        {
            XmlSerializer serializer = new XmlSerializer(typeof(List<Holiday>));
            List<Holiday> holidays;

            using (FileStream fs = new FileStream(GetXmlPath(), FileMode.Open))
            {
                holidays = (List<Holiday>)serializer.Deserialize(fs);
            }
            return holidays;
        }

        public void CreateHoliday(Holiday holiday)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(Holiday));
            using (FileStream fs = new FileStream(GetXmlPath(), FileMode.Append))
            {
                serializer.Serialize(fs, holiday);
            }
        }



        public string GetXmlPath()
        {
            return _service.GetXMLPath()+"XmlHolidayRepository.xml";
            
        }
    }
}
