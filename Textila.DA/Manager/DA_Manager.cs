using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using textila.shared;
using Textila.Shared;

namespace Textila.DA.Manager
{
    public class DA_Manager
    {
        public DA_Manager()
        {

        }

        public List<CountEntity> getAllCounts()
        {
            using(var db = new textilaEntities())
            {
                return db.Counts.ToList().Select(e => new CountEntity {
                    Blend = e.Blend ?? 0,
                    CountId = e.CountId,
                    CountName = e.CountName,
                    SingleDouble = e.SingleDouble,
                    CreatedBy = e.CreatedBy,
                    CreatedOn = e.CreatedOn,
                    Description = e.Description,
                    ModifiedBy = e.ModifiedBy,
                    ModifiedOn = e.ModifiedOn
                }).ToList();
            }
        }

        public CountEntity getCountById( int id )
        {
            using (var db = new textilaEntities())
            {
                return db.Counts.Where(e => e.CountId == id).Select(e => new CountEntity
                {
                    Blend = e.Blend ?? 0,
                    CountId = e.CountId,
                    CountName = e.CountName,
                    SingleDouble = e.SingleDouble,
                    CreatedBy = e.CreatedBy,
                    CreatedOn = e.CreatedOn,
                    Description = e.Description,
                    ModifiedBy = e.ModifiedBy,
                    ModifiedOn = e.ModifiedOn
                }).FirstOrDefault();
            }
        }


        public List<BlendEntity> getAllBlends(string search)
        {
            using (var db = new textilaEntities())
            {
                List<Blend> blends;
                if (string.IsNullOrWhiteSpace(search))
                {
                    blends = db.Blends.ToList();
                }
                else
                {
                    blends = db.Blends.Where(e=>e.BlendName.Contains(search)).ToList();
                }
                return blends.Select(e => new BlendEntity
                {
                    BlendId = e.BlendId,
                    BlendName = e.BlendName
                }).ToList();
            }
        }

        public BlendEntity getBlendById( int id )
        {
            using (var db = new textilaEntities())
            {
                return db.Blends.Where(e => e.BlendId == id).Select(e => new BlendEntity
                {
                    BlendId = e.BlendId,
                    BlendName = e.BlendName
                }).FirstOrDefault();
            }
        }

        public bool saveBlend( BlendEntity obj )
        {
            Blend blend = new Blend
            {
                BlendName = obj.BlendName
            };
            using (var db = new textilaEntities())
            {
                try
                {
                    blend= db.Blends.Add(blend);
                    db.SaveChanges();
                }
                catch (Exception e)
                {
                    return false;
                }

            }
            return true;
        }

        public bool saveCount(CountEntity obj)
        {
            Count count = new Count
            {
                Blend = obj.Blend,
                CountId = obj.CountId,
                CountName = obj.CountName,
                SingleDouble = obj.SingleDouble,
                CreatedBy = obj.CreatedBy,
                CreatedOn = obj.CreatedOn,
                Description = obj.Description,
                ModifiedBy = obj.ModifiedBy,
                ModifiedOn = obj.ModifiedOn
            };
            using (var db = new textilaEntities())
            {
                try
                {
                    db.Counts.Add(count);
                    db.SaveChanges();
                }
                catch (Exception e)
                {
                    return false;
                }

            }
            return true;
        }

        public bool updateCount(int id, CountEntity obj)
        {

            Count count = new Count
            {
                CountId = id,
                Blend = obj.Blend,
                CountName = obj.CountName,
                SingleDouble = obj.SingleDouble,
                CreatedBy = obj.CreatedBy,
                CreatedOn = obj.CreatedOn,
                Description = obj.Description,
                ModifiedBy = obj.ModifiedBy,
                ModifiedOn = obj.ModifiedOn
            };
            using (var db = new textilaEntities())
            {
                try
                {
                    var result = db.Counts.SingleOrDefault(b => b.CountId == id);
                    result = count;
                    db.SaveChanges();
                }
                catch (Exception)
                {
                    return false;
                }

            }
            return true;
        }

        public bool updateBlend(int id, BlendEntity obj)
        {

            Blend blend = new Blend
            {
                BlendId = id,
                BlendName = obj.BlendName
            };
            using (var db = new textilaEntities())
            {
                try
                {
                    var result = db.Blends.SingleOrDefault(b => b.BlendId == id);
                    result = blend;
                    db.SaveChanges();
                }
                catch (Exception)
                {
                    return false;
                }

            }
            return true;
        }

        public bool deleteCount(CountEntity obj)
        {

            Count count = new Count
            {
                CountId = obj.CountId,
                Blend = obj.Blend,
                CountName = obj.CountName,
                SingleDouble = obj.SingleDouble,
                CreatedBy = obj.CreatedBy,
                CreatedOn = obj.CreatedOn,
                Description = obj.Description,
                ModifiedBy = obj.ModifiedBy,
                ModifiedOn = obj.ModifiedOn
            };

            using (var db = new textilaEntities())
            {
                try
                {
                    db.Counts.Remove(count);
                }
                catch (Exception)
                {
                    return false;
                }
                return true;
            }
        }
        
        public bool deleteBlend(BlendEntity obj)
        {
            Blend blend = new Blend
            {
                BlendId = obj.BlendId,
                BlendName = obj.BlendName
            };

            using (var db = new textilaEntities())
            {
                try
                {
                    db.Blends.Remove(blend);
                }
                catch (Exception)
                {
                    return false;
                }
                return true;
            }
        }
    }
}
