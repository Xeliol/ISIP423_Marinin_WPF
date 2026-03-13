using System;
using System.Collections.Generic;
using System.Data.Entity.Core.Metadata.Edm;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp1
{
    internal class Class
    {
    }

    public static class NavigationData
    {
        public static object CurrentData
        {
            get; set;
        }
    }

    public partial class basepart_
    {
        public string Description
        {
            get
            {
                string desc = "";
                switch(parttypeid)
                {
                    case 1:
                        var part = Core.Context.cpu_.Where(c => c.id == id).First();
                        desc = $"Cores: {part.numberofcores}\n" +
                            $"Base Freq.: {part.basecorefrequency}\n" +
                            $"Max Freq.: {part.maxcorefrequency}\n" +
                            $"Cachel3: {part.cachel3}\n" +
                            $"Thermal Pow.: {part.thermalpower}\n" +
                            $"Has IGPU: {part.hasigpu}";
                        if (part.hasigpu)
                        {
                            desc += $"\nIGPU: {Core.Context.igpu_.Where(c => c.id == part.igpuid).First().name}";
                        }
                        break;
                    case 2:
                        var part1 = Core.Context.gpu_.Where(c => c.id == id).First();
                        desc = $"Interface: {Core.Context.gpuinterface_.Where(c => c.id == part1.gpuinterfaceid).First().name}\n" +
                            $"Chip Freq.: {part1.chipfrequency}\n" +
                            $"Video Mem.: {part1.videomemory}\n" +
                            $"Memory Bus: {part1.memorybus}\n" +
                            $"Recommended Pow.: {part1.recommendpower}";
                        break;
                    case 3:
                        var part2 = Core.Context.ram_.Where(c => c.id == id).First();
                        desc = $"Mem. Type: {Core.Context.memorytype_.Where(c => c.id == part2.memorytypeid).First().name}\n" +
                            $"Capacity: {part2.capacity}\n" +
                            $"Count: {part2.count}\n" +
                            $"GHz: {part2.ghz}\n" +
                            $"Timings: {part2.timings}";
                        break;
                    case 4:
                        var part3 = Core.Context.motherboard_.Where(c => c.id == id).First();
                        desc = $"Socket: {Core.Context.socket_.Where(c => c.id == part3.socketid).First().name}\n" +
                            $"Form Factor: {Core.Context.formfactor_.Where(c => c.id == part3.formfactorid).First().name}\n" +
                            $"Mem. Slots: {part3.memoryslots}\n" +
                            $"PCI Slots: {part3.pcislots}\n" +
                            $"SATA Ports: {part3.sataports}\n" +
                            $"USB Ports: {part3.usbports}";
                        break;
                    case 5:
                        var part4 = Core.Context.case_.Where(c => c.id == id).First();
                        desc = $"Size: {Core.Context.casesize_.Where(c => c.id == part4.sizeid).First().name}\n" +
                            $"Expansion Slots: {part4.expansionslots}\n" +
                            $"Fans: {part4.fans}";
                        break;
                    case 6:
                        var part5 = Core.Context.powersupply_.Where(c => c.id == id).First();
                        desc = $"Power: {part5.power}\n" +
                            $"Fan Dimension: {Core.Context.fandimension_.Where(c => c.id == part5.fandimensionid).First().name}\n" +
                            $"Certification: {Core.Context.certificate_.Where(c => c.id == part5.certificationid).First().name}";
                        break;
                    case 7:
                        var part6 = Core.Context.processorcooler_.Where(c => c.id == id).First();
                        desc = $"Fan Dimension: {Core.Context.fandimension_.Where(c => c.id == part6.fandimensionid).First().name}\n" +
                            $"Heat Pipes: {part6.heatpipes}\n" +
                            $"Min. Speed: {part6.minspeed}\n" +
                            $"Max. Speed: {part6.maxspeed}\n" +
                            $"Noise Level: {part6.noiselevel}";
                        break;
                    case 8:
                        var part7 = Core.Context.storagedevice_.Where(c => c.id == id).First();
                        desc = $"Capacity: {part7.capacity}\n" +
                            $"Interface: {Core.Context.storagedeviceinterface_.Where(c => c.id == part7.storagedeviceinterfaceid).First().name}\n" +
                            $"Type: {Core.Context.storagedevicetype_.Where(c => c.id == part7.storagedevicetypeid).First().name}";
                        break;
                }
                return desc;
            }
        }
    }
}
