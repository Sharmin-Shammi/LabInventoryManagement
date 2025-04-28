using Business.FormModel;
using Database.Context;
using Database.Model;
using System.Linq;

namespace Business.Services
{
    public class DocumentService
    {
        LabInventoryContext labInventoryContext = new LabInventoryContext();

        // Add new document
        public Result Add(DocumentForm document)
        {
            try
            {
                Document newDocument = new Document();
                newDocument.DocumentName = document.DocumentName;
                newDocument.DocumentType = document.DocumentType;
                newDocument.TransactionQuality = document.TransactionQuality;
                newDocument.UserId = document.UserId;
                newDocument.TransactionId = document.TransactionId;
                newDocument.CreatedBy = document.CreatedBy;

                labInventoryContext.Document.Add(newDocument);
                return new Result().DBCommit(labInventoryContext, "Document added successfully!", null, document);
            }
            catch (Exception ex)
            {
                return new Result(false, ex.Message);
            }
        }

        // Update document
        public Result Update(DocumentForm document)
        {
            try
            {
                var existingDocument = labInventoryContext.Document.FirstOrDefault(x => x.DocumentId == document.DocumentId);
                if (existingDocument == null) return new Result(false, "Document not found!");

                existingDocument.DocumentName = document.DocumentName;
                existingDocument.DocumentType = document.DocumentType;
                existingDocument.TransactionQuality = document.TransactionQuality;
                existingDocument.UserId = document.UserId;
                existingDocument.TransactionId = document.TransactionId;
                existingDocument.UpdatedBy = document.UpdatedBy;
                existingDocument.UpdatedDate = DateTime.Now;

                return new Result().DBCommit(labInventoryContext, "Document updated successfully!", null, document);
            }
            catch (Exception ex)
            {
                return new Result(false, ex.Message);
            }
        }

        // Delete document
        public Result Delete(string documentId)
        {
            try
            {
                var document = labInventoryContext.Document.FirstOrDefault(x => x.DocumentId == documentId);
                if (document == null) return new Result(false, "Document not found!");

                labInventoryContext.Document.Remove(document);
                return new Result().DBCommit(labInventoryContext, "Document deleted successfully!", null, document);
            }
            catch (Exception ex)
            {
                return new Result(false, ex.Message);
            }
        }

        // List all documents
        public Result List()
        {
            try
            {
                var documents = labInventoryContext.Document.ToList();
                return new Result(true, "Documents fetched successfully!", documents);
            }
            catch (Exception ex)
            {
                return new Result(false, ex.Message);
            }
        }

        // Get single document
        public Result Single(string documentId)
        {
            try
            {
                var document = labInventoryContext.Document.FirstOrDefault(x => x.DocumentId == documentId);
                if (document == null) return new Result(false, "Document not found!");

                return new Result(true, "Document fetched successfully!", document);
            }
            catch (Exception ex)
            {
                return new Result(false, ex.Message);
            }
        }
    }
}

