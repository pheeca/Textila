using System;
using System.Collections.Generic;
using textila.shared;
using Textila.DA.Manager;
using Textila.Shared;

namespace Textila.BL
{
    public class BL_Manager
    {
        DA_Manager DA;

        public BL_Manager()
        {
            DA = new DA_Manager();
        }

        public List<CountEntity> getAllCounts()
        {
            return DA.getAllCounts();
        }
        public List<BlendEntity> getAllBlends()
        {
            return DA.getAllBlends();
        }

        public CountEntity getCountById(int id)
        {
            return DA.getCountById(id);
        }

        public BlendEntity getBlendById(int id)
        {
            return DA.getBlendById(id);
        }

        public bool saveCount(CountEntity count)
        {
            return DA.saveCount(count);
        }

        public bool saveBlend(BlendEntity blend)
        {
            return DA.saveBlend(blend);
        }

        public bool updateCount(int id, CountEntity count)
        {
            return DA.updateCount(id, count);
        }

        public bool updateBlend(int id, BlendEntity blend)
        {
            return DA.updateBlend(id, blend);
        }

        public bool deleteCount(CountEntity count)
        {
            return DA.deleteCount(count);
        }
        public bool deleteBlend(BlendEntity blend)
        {
            return DA.deleteBlend(blend);
        }
    }
}
