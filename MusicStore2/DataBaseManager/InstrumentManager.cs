using MusicStore2.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace MusicStore2.DataBaseManager
{
    public class InstrumentManager
    {
        public static List<Instrument> GetInstruments()
        {
            var result = new List<Instrument>();
            using (DataBaseContext db = new DataBaseContext())
            {
                try
                {
                    result = db.Instruments.ToList();
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Ошибка валидации" + ex.Message.ToString());
                    Console.ReadLine();
                    result = null;
                }
            }
            return result;
        }
        public static async Task<List<Instrument>> GetInstrumentsAsync()
        {
            var result = new List<Instrument>();
            using (DataBaseContext db = new DataBaseContext())
            {
                try
                {
                    result = await db.Instruments.ToListAsync();
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Ошибка валидации" + ex.Message.ToString());
                    Console.ReadLine();
                    result = null;
                }
            }
            return result;
        }
        public static Instrument Get(Guid id)
        {
            using (DataBaseContext db = new DataBaseContext())
            {
                var res = db.Instruments.ToList();

                foreach (var inst in db.Instruments)
                {
                    if (inst.Id == id)
                        return inst;
                }
                return null;
            }
        }
        public static async Task<Instrument> GetAsync(Guid id)
        {
            using (DataBaseContext db = new DataBaseContext())
            {
                var res = await db.Instruments.ToListAsync();

                foreach (var inst in db.Instruments)
                {
                    if (inst.Id == id)
                        return inst;
                }
                return null;
            }
        }
        public static void AddInstrument(Instrument inst)
        {
            inst.Id = Guid.NewGuid();
            using (DataBaseContext db = new DataBaseContext())
            {
                db.Instruments.Add(inst);
                db.SaveChanges();
            }
        }
        public static async Task<bool> AddInstrumentAsync(Instrument inst)
        {
            if (inst != null)
            {
                inst.Id = Guid.NewGuid();
                using (DataBaseContext db = new DataBaseContext())
                {
                    db.Instruments.Add(inst);
                    await db.SaveChangesAsync();
                }
                return true;

            }
            else
            {
                return false;
            }

        }
        public static void DeleteIntrument(Guid id)
        {
             using (DataBaseContext db = new DataBaseContext())
             {
                var temp = new Instrument();
                foreach (var item in db.Instruments)
                {
                    if (item.Id == id)
                    {
                            temp = item;
                    }

                }
                    db.Instruments.Remove(temp);
                    db.SaveChanges();
             }
        }
        public static async Task<bool> DeleteIntrumentAsync(Guid id)
        {
            using (DataBaseContext db = new DataBaseContext())
            {
                var temp = new Instrument();
                foreach (var item in db.Instruments)
                {
                    if (item.Id == id)
                    {
                        temp = item;
                    }
                }
                db.Instruments.Remove(temp);
                await db.SaveChangesAsync();
                return true;
            }
        }
        public static void EditInstrument(Instrument inst)
        {
            using (DataBaseContext db = new DataBaseContext())
            {
                var inst2 = db.Instruments.SingleOrDefault(x => x.Id == inst.Id);
                inst2.Name = inst.Name;
                inst2.Price = inst.Price;
                inst2.Description = inst.Description;
                inst2.ImgUrl = inst.ImgUrl;
                inst2.Category = inst.Category;
                inst2.SubCategory = inst.SubCategory;
                db.SaveChanges();
            }
        }
        public static async Task<bool> EditInstrumentAsync(Instrument inst)
        {
            using (DataBaseContext db = new DataBaseContext())
            {
                var inst2 = await db.Instruments.SingleOrDefaultAsync(x => x.Id == inst.Id);
                if(inst2 != null)
                {
                    inst2.Name = inst.Name;
                    inst2.Price = inst.Price;
                    inst2.Description = inst.Description;
                    inst2.ImgUrl = inst.ImgUrl;
                    inst2.Category = inst.Category;
                    inst2.SubCategory = inst.SubCategory;
                    await db.SaveChangesAsync();
                    return true;
                }
                else
                {
                    return false;
                }  
            }
        }
        public static bool BuyInstrument(Guid id)
        {
            using (DataBaseContext db = new DataBaseContext())
            {
                foreach (var inst in db.Instruments)
                {
                    if (inst.Id == id)
                        return true;
                }
                return false;
            }
        }
    }
}