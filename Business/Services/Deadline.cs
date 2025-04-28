using Business.FormModel;
using Database.Context;
using Database.Model;
using System.Linq;

namespace Business.Services
{
    public class DeadlineService
    {
        LabInventoryContext labInventoryContext = new LabInventoryContext();

        // Add new deadline
        public Result Add(DeadlineForm deadline)
        {
            try
            {
                Deadline newDeadline = new Deadline();
                newDeadline.ItemId = deadline.ItemId;
                newDeadline.DeadlineDate = deadline.DeadlineDate;
                newDeadline.DeadlineType = deadline.DeadlineType;
                newDeadline.UserId = deadline.UserId;
                newDeadline.CreatedBy = deadline.CreatedBy;

                labInventoryContext.Deadline.Add(newDeadline);
                return new Result().DBCommit(labInventoryContext, "Deadline added successfully!", null, deadline);
            }
            catch (Exception ex)
            {
                return new Result(false, ex.Message);
            }
        }

        // Update deadline
        public Result Update(DeadlineForm deadline)
        {
            try
            {
                var existingDeadline = labInventoryContext.Deadline.FirstOrDefault(x => x.DeadlineId == deadline.DeadlineId);
                if (existingDeadline == null) return new Result(false, "Deadline not found!");

                existingDeadline.ItemId = deadline.ItemId;
                existingDeadline.DeadlineDate = deadline.DeadlineDate;
                existingDeadline.DeadlineType = deadline.DeadlineType;
                existingDeadline.UserId = deadline.UserId;
                existingDeadline.UpdatedBy = deadline.UpdatedBy;
                existingDeadline.UpdatedDate = DateTime.Now;

                return new Result().DBCommit(labInventoryContext, "Deadline updated successfully!", null, deadline);
            }
            catch (Exception ex)
            {
                return new Result(false, ex.Message);
            }
        }

        // Delete deadline
        public Result Delete(string deadlineId)
        {
            try
            {
                var deadline = labInventoryContext.Deadline.FirstOrDefault(x => x.DeadlineId == deadlineId);
                if (deadline == null) return new Result(false, "Deadline not found!");

                labInventoryContext.Deadline.Remove(deadline);
                return new Result().DBCommit(labInventoryContext, "Deadline deleted successfully!", null, deadline);
            }
            catch (Exception ex)
            {
                return new Result(false, ex.Message);
            }
        }

        // List all deadlines
        public Result List()
        {
            try
            {
                var deadlines = labInventoryContext.Deadline.ToList();
                return new Result(true, "Deadlines fetched successfully!", deadlines);
            }
            catch (Exception ex)
            {
                return new Result(false, ex.Message);
            }
        }

        // Get single deadline
        public Result Single(string deadlineId)
        {
            try
            {
                var deadline = labInventoryContext.Deadline.FirstOrDefault(x => x.DeadlineId == deadlineId);
                if (deadline == null) return new Result(false, "Deadline not found!");

                return new Result(true, "Deadline fetched successfully!", deadline);
            }
            catch (Exception ex)
            {
                return new Result(false, ex.Message);
            }
        }
    }
}
