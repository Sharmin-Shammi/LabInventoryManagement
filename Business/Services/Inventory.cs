using Business.FormModel;
using Database.Context;
using Database.Model;
using System.Linq;

namespace Business.Services
{
    public class InventoryService
    {
        LabInventoryContext labInventoryContext = new LabInventoryContext();

        // Add new inventory item
        public Result Add(InventoryForm inventory)
        {
            try
            {
                Inventory item = new Inventory();
                item.ItemName = inventory.ItemName;
                item.ItemDetails = inventory.ItemDetails;
                item.QuantityInstock = inventory.QuantityInstock;
                item.UnitPrice = inventory.UnitPrice;
                item.SupplierId = inventory.SupplierId;
                item.CreatedBy = inventory.CreatedBy;

                labInventoryContext.Inventory.Add(item);
                return new Result().DBCommit(labInventoryContext, "Inventory item added successfully!", null, inventory);
            }
            catch (Exception ex)
            {
                return new Result(false, ex.Message);
            }
        }

        // Update existing inventory item
        public Result Update(InventoryForm inventory)
        {
            try
            {
                var existingItem = labInventoryContext.Inventory.FirstOrDefault(x => x.ItemId == inventory.ItemId);
                if (existingItem == null) return new Result(false, "Inventory item not found!");

                existingItem.ItemName = inventory.ItemName;
                existingItem.ItemDetails = inventory.ItemDetails;
                existingItem.QuantityInstock = inventory.QuantityInstock;
                existingItem.UnitPrice = inventory.UnitPrice;
                existingItem.SupplierId = inventory.SupplierId;
                existingItem.UpdatedBy = inventory.UpdatedBy;
                existingItem.UpdatedDate = DateTime.Now;

                return new Result().DBCommit(labInventoryContext, "Inventory item updated successfully!", null, inventory);
            }
            catch (Exception ex)
            {
                return new Result(false, ex.Message);
            }
        }

        // Delete inventory item
        public Result Delete(string itemId)
        {
            try
            {
                var item = labInventoryContext.Inventory.FirstOrDefault(x => x.ItemId == itemId);
                if (item == null) return new Result(false, "Item not found!");

                labInventoryContext.Inventory.Remove(item);
                return new Result().DBCommit(labInventoryContext, "Item deleted successfully!", null, item);
            }
            catch (Exception ex)
            {
                return new Result(false, ex.Message);
            }
        }

        // List all inventory items
        public Result List()
        {
            try
            {
                var items = labInventoryContext.Inventory.ToList();
                return new Result(true, "Inventory items fetched successfully!", items);
            }
            catch (Exception ex)
            {
                return new Result(false, ex.Message);
            }
        }

        // Get single inventory item
        public Result Single(string itemId)
        {
            try
            {
                var item = labInventoryContext.Inventory.FirstOrDefault(x => x.ItemId == itemId);
                if (item == null) return new Result(false, "Item not found!");

                return new Result(true, "Item fetched successfully!", item);
            }
            catch (Exception ex)
            {
                return new Result(false, ex.Message);
            }
        }
    }
}
