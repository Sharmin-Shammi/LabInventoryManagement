using Business.FormModel;
using Database.Context;
using Database.Model;
using System.Linq;

namespace Business.Services
{
    public class SupplierService
    {
        LabInventoryContext labInventoryContext = new LabInventoryContext();

        // Add new supplier
        public Result Add(SupplierForm supplier)
        {
            try
            {
                Supplier newSupplier = new Supplier();
                newSupplier.SupplierName = supplier.SupplierName;
                newSupplier.SupplierEmail = supplier.SupplierEmail;
                newSupplier.SupplierPhoneNumber = supplier.SupplierPhoneNumber;
                newSupplier.SupplierAddress = supplier.SupplierAddress;
                newSupplier.SupplyCatogory = supplier.SupplyCatogory;
                newSupplier.CreatedBy = supplier.CreatedBy;

                labInventoryContext.Supplier.Add(newSupplier);
                return new Result().DBCommit(labInventoryContext, "Supplier added successfully!", null, supplier);
            }
            catch (Exception ex)
            {
                return new Result(false, ex.Message);
            }
        }

        // Update supplier
        public Result Update(SupplierForm supplier)
        {
            try
            {
                var existingSupplier = labInventoryContext.Supplier.FirstOrDefault(x => x.SupplierId == supplier.SupplierId);
                if (existingSupplier == null) return new Result(false, "Supplier not found!");

                existingSupplier.SupplierName = supplier.SupplierName;
                existingSupplier.SupplierEmail = supplier.SupplierEmail;
                existingSupplier.SupplierPhoneNumber = supplier.SupplierPhoneNumber;
                existingSupplier.SupplierAddress = supplier.SupplierAddress;
                existingSupplier.SupplyCatogory = supplier.SupplyCatogory;
                existingSupplier.UpdatedBy = supplier.UpdatedBy;
                existingSupplier.UpdatedDate = DateTime.Now;

                return new Result().DBCommit(labInventoryContext, "Supplier updated successfully!", null, supplier);
            }
            catch (Exception ex)
            {
                return new Result(false, ex.Message);
            }
        }

        // Delete supplier
        public Result Delete(string supplierId)
        {
            try
            {
                var supplier = labInventoryContext.Supplier.FirstOrDefault(x => x.SupplierId == supplierId);
                if (supplier == null) return new Result(false, "Supplier not found!");

                labInventoryContext.Supplier.Remove(supplier);
                return new Result().DBCommit(labInventoryContext, "Supplier deleted successfully!", null, supplier);
            }
            catch (Exception ex)
            {
                return new Result(false, ex.Message);
            }
        }

        // List all suppliers
        public Result List()
        {
            try
            {
                var suppliers = labInventoryContext.Supplier.ToList();
                return new Result(true, "Suppliers fetched successfully!", suppliers);
            }
            catch (Exception ex)
            {
                return new Result(false, ex.Message);
            }
        }

        // Get single supplier
        public Result Single(string supplierId)
        {
            try
            {
                var supplier = labInventoryContext.Supplier.FirstOrDefault(x => x.SupplierId == supplierId);
                if (supplier == null) return new Result(false, "Supplier not found!");

                return new Result(true, "Supplier fetched successfully!", supplier);
            }
            catch (Exception ex)
            {
                return new Result(false, ex.Message);
            }
        }
    }
}

