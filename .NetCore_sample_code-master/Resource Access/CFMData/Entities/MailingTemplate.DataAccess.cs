﻿//------------------------------------------------------------------------------
// <autogenerated>
//     
//     Changes to this file will be lost after each regeneration.
//     To extend the functionality of this class, please modify the partial class 'MailingTemplate.cs'.
//
//     Template: EditableRoot.DataAccess.StoredProcedures.cst
//     
// </autogenerated>
//------------------------------------------------------------------------------
using System;
using System.Data;
using System.Data.SqlClient;
 using Dapper;

namespace CFMData
{
	public partial class MailingTemplate
	{
    
		private MailingTemplate DataPortal_Fetch(MailingTemplateCriteria criteria)
		{
 
			bool cancel = false;
			OnFetching(criteria, ref cancel);
			if (cancel) return null;
			using (var connection = new SqlConnection(ADOHelper.ConnectionString))
			{
				connection.Open();
				using (var command = new SqlCommand("[dbo].[spCFM_MailingTemplate_Select]", connection))
				{
					command.CommandType = CommandType.StoredProcedure;
					command.Parameters.AddRange(ADOHelper.SqlParameters(criteria.StateBag));
                    command.Parameters.AddWithValue("@p_DescriptionHasValue", criteria.DescriptionHasValue);
                command.Parameters.AddWithValue("@p_MailingTextHasValue", criteria.MailingTextHasValue);
                command.Parameters.AddWithValue("@p_MailingSubjectHasValue", criteria.MailingSubjectHasValue);
                command.Parameters.AddWithValue("@p_MailingFromHasValue", criteria.MailingFromHasValue);
                command.Parameters.AddWithValue("@p_UpdatedByHasValue", criteria.UpdatedByHasValue);
                command.Parameters.AddWithValue("@p_UpdatedOnHasValue", criteria.UpdatedOnHasValue);
					using(var reader = command.ExecuteReader())
					{
						var rowParser = reader.GetRowParser<MailingTemplate>();                       
						if(reader.Read())
						{
							return GetMailingTemplate(rowParser, reader);							
						}                            
						else
							throw new Exception(String.Format("The record was not found in 'dbo.MailingTemplate' using the following criteria: {0}.", criteria));
					}
				}
			}
			OnFetched();
		}

       // [Transactional(TransactionalTypes.TransactionScope)]
		protected   void DataPortal_Insert()
		{
			bool cancel = false;
			OnInserting(ref cancel);
			if (cancel) return;
			using (var connection = new SqlConnection(ADOHelper.ConnectionString))
			{
				connection.Open();
				SqlTransaction trans = connection.BeginTransaction();
				try
				{
				
				using(var command = new SqlCommand("[dbo].[spCFM_MailingTemplate_Insert]", connection,trans))
				{
					command.CommandType = CommandType.StoredProcedure;
					
          command.Parameters.AddWithValue("@p_MailingTemplateID", this.MailingTemplateID);
                command.Parameters.AddWithValue("@p_Description", ADOHelper.NullCheck(this.Description));
                command.Parameters.AddWithValue("@p_MailingText", ADOHelper.NullCheck(this.MailingText));
                command.Parameters.AddWithValue("@p_MailingSubject", ADOHelper.NullCheck(this.MailingSubject));
                command.Parameters.AddWithValue("@p_MailingFrom", ADOHelper.NullCheck(this.MailingFrom));
                command.Parameters.AddWithValue("@p_CreatedBy", this.CreatedBy);
                command.Parameters.AddWithValue("@p_CreatedOn", this.CreatedOn);
                command.Parameters.AddWithValue("@p_UpdatedBy", ADOHelper.NullCheck(this.UpdatedBy));
                command.Parameters.AddWithValue("@p_UpdatedOn", ADOHelper.NullCheck(this.UpdatedOn));
					command.ExecuteNonQuery();                  
                    
				}
                
				_originalMailingTemplateIDProperty= this.MailingTemplateID;
				UpdateChildren(this, connection,trans);
				
				trans.Commit();
			}
			catch(Exception ex)
			{
				trans.Rollback();
				throw;
			}
			
		}
			

			OnInserted();

		}

       // [Transactional(TransactionalTypes.TransactionScope)]
		protected   void DataPortal_Update()
		{
			bool cancel = false;
			OnUpdating(ref cancel);
			if (cancel) return;
            if(OriginalMailingTemplateID != MailingTemplateID)
            {
                // Insert new child.
				MailingTemplate item = new MailingTemplate {MailingTemplateID = MailingTemplateID, Description = Description, MailingText = MailingText, MailingSubject = MailingSubject, MailingFrom = MailingFrom, CreatedBy = CreatedBy, CreatedOn = CreatedOn};
				                if(UpdatedBy.HasValue) item.UpdatedBy = UpdatedBy.Value;
                if(UpdatedOn.HasValue) item.UpdatedOn = UpdatedOn.Value;
				item.DataPortal_Update();

                // Mark editable child lists as dirty. This code may need to be updated to one-to-one relationships.
				foreach(EmailQueue itemToUpdate in EmailQueues)
				{
                itemToUpdate.MailingTemplateID = MailingTemplateID;
				}

				// Create a new connection.
				using (var connection = new SqlConnection(ADOHelper.ConnectionString))
				{
					connection.Open();
					SqlTransaction trans = connection.BeginTransaction();
					try
					{
						UpdateChildren(this, connection,trans);
						trans.Commit();
					}
					catch(Exception ex)
					{
						trans.Rollback();
						throw;
					}
					
					//FieldManager.UpdateChildren(this, connection);
				}
				// Delete the old.
				var criteria = new MailingTemplateCriteria {MailingTemplateID = OriginalMailingTemplateID};
				
				DataPortal_Delete(criteria);

				// Mark the original as the new one.
				OriginalMailingTemplateID = MailingTemplateID;
				OnUpdated();

				return;
			}

			using (var connection = new SqlConnection(ADOHelper.ConnectionString))
			{
				connection.Open();
				SqlTransaction trans = connection.BeginTransaction();
				try
				{
				using(var command = new SqlCommand("[dbo].[spCFM_MailingTemplate_Update]", connection,trans))
				{
					command.CommandType = CommandType.StoredProcedure;
					command.Parameters.AddWithValue("@p_OriginalMailingTemplateID", this.OriginalMailingTemplateID);
                command.Parameters.AddWithValue("@p_MailingTemplateID", this.MailingTemplateID);
                command.Parameters.AddWithValue("@p_Description", ADOHelper.NullCheck(this.Description));
                command.Parameters.AddWithValue("@p_MailingText", ADOHelper.NullCheck(this.MailingText));
                command.Parameters.AddWithValue("@p_MailingSubject", ADOHelper.NullCheck(this.MailingSubject));
                command.Parameters.AddWithValue("@p_MailingFrom", ADOHelper.NullCheck(this.MailingFrom));
                command.Parameters.AddWithValue("@p_CreatedBy", this.CreatedBy);
                command.Parameters.AddWithValue("@p_CreatedOn", this.CreatedOn);
                command.Parameters.AddWithValue("@p_UpdatedBy", ADOHelper.NullCheck(this.UpdatedBy));
                command.Parameters.AddWithValue("@p_UpdatedOn", ADOHelper.NullCheck(this.UpdatedOn));
					//result: The number of rows changed, inserted, or deleted. -1 for select statements; 0 if no rows were affected, or the statement failed. 
					int result = command.ExecuteNonQuery();
					if (result == 0)
						throw new DBConcurrencyException("The entity is out of date on the client. Please update the entity and try again. This could also be thrown if the sql statement failed to execute.");

					_originalMailingTemplateIDProperty= this.MailingTemplateID;
				}
				UpdateChildren(this, connection,trans);
				//FieldManager.UpdateChildren(this, connection);
				trans.Commit();
			}
			catch(Exception ex)
			{
				trans.Rollback();
				throw;
			}
			
		}

			OnUpdated();
		}
		protected   void UpdateChildren(MailingTemplate parent,SqlConnection connection,SqlTransaction trans)
		{
		
		
			
			if(_emailQueuesPropertyChecked )
			{
				if(_emailQueuesProperty!=null)
				{
				
					foreach (EmailQueue obj in _emailQueuesProperty)
					{
						if (obj.IsNew)
						{
							obj.Child_Insert(parent, connection,trans);
						}
						else
						{
							if (obj.IsDirty ||  obj.IsChildDirty())
							{							
								obj.Child_Update(parent, connection,trans);
							}
						}
					}
				}
					
 
			}


		}

		protected   void DataPortal_DeleteSelf()
		{
			bool cancel = false;
			OnSelfDeleting(ref cancel);
			if (cancel) return;            
			DataPortal_Delete(new MailingTemplateCriteria (MailingTemplateID));        
			OnSelfDeleted();
		}
        
		//[Transactional(TransactionalTypes.TransactionScope)]
		protected void DataPortal_Delete(MailingTemplateCriteria criteria)
		{
            bool cancel = false;
            OnDeleting(criteria, ref cancel);
            if (cancel) return;

            using (var connection = new SqlConnection(ADOHelper.ConnectionString))
            {
                connection.Open();
                using (var command = new SqlCommand("[dbo].[spCFM_MailingTemplate_Delete]", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
		
                    command.Parameters.AddRange(ADOHelper.SqlParameters(criteria.StateBag));

                    //result: The number of rows changed, inserted, or deleted. -1 for select statements; 0 if no rows were affected, or the statement failed. 
                    int result = command.ExecuteNonQuery();
                    if (result == 0)
                        throw new DBConcurrencyException("The entity is out of date on the client. Please update the entity and try again. This could also be thrown if the sql statement failed to execute.");
                }
            }

            OnDeleted();
		}
		
		 #region Child_Insert
        /// <summary>
        /// Inserts data into the data base using the information in the current 
        ///    CSLA editable child business object of type <see cref="MailingTemplate"/> 
        /// </summary>
        /// <returns></returns>
        public void Child_Insert(SqlConnection connection,SqlTransaction trans)
        {
            bool cancel = false;
            OnChildInserting(connection, ref cancel,trans);
            if (cancel) return;

            if(connection.State != ConnectionState.Open) connection.Open();
            using(var command = new SqlCommand("[dbo].[spCFM_MailingTemplate_Insert]", connection,trans))
            {
                command.CommandType = CommandType.StoredProcedure;
		
                command.Parameters.AddWithValue("@p_MailingTemplateID", this.MailingTemplateID);
                command.Parameters.AddWithValue("@p_Description", ADOHelper.NullCheck(this.Description));
                command.Parameters.AddWithValue("@p_MailingText", ADOHelper.NullCheck(this.MailingText));
                command.Parameters.AddWithValue("@p_MailingSubject", ADOHelper.NullCheck(this.MailingSubject));
                command.Parameters.AddWithValue("@p_MailingFrom", ADOHelper.NullCheck(this.MailingFrom));
                command.Parameters.AddWithValue("@p_CreatedBy", this.CreatedBy);
                command.Parameters.AddWithValue("@p_CreatedOn", this.CreatedOn);
                command.Parameters.AddWithValue("@p_UpdatedBy", ADOHelper.NullCheck(this.UpdatedBy));
                command.Parameters.AddWithValue("@p_UpdatedOn", ADOHelper.NullCheck(this.UpdatedOn));

                command.ExecuteNonQuery();

                // Update the original non-identity primary key value.
                _originalMailingTemplateIDProperty= this.MailingTemplateID;
            }

            UpdateChildren(this, connection,trans);

            OnChildInserted();
        }

        public void Child_Insert(ApplicationUser applicationUser, SqlConnection connection,SqlTransaction trans)
        {
            bool cancel = false;
            OnChildInserting(applicationUser, connection, ref cancel,trans);
            if (cancel) return;

            if(connection.State != ConnectionState.Open) connection.Open();
            using(var command = new SqlCommand("[dbo].[spCFM_MailingTemplate_Insert]", connection,trans))
            {
                command.CommandType = CommandType.StoredProcedure;
		
                command.Parameters.AddWithValue("@p_MailingTemplateID", this.MailingTemplateID);
                command.Parameters.AddWithValue("@p_Description", ADOHelper.NullCheck(this.Description));
                command.Parameters.AddWithValue("@p_MailingText", ADOHelper.NullCheck(this.MailingText));
                command.Parameters.AddWithValue("@p_MailingSubject", ADOHelper.NullCheck(this.MailingSubject));
                command.Parameters.AddWithValue("@p_MailingFrom", ADOHelper.NullCheck(this.MailingFrom));
                command.Parameters.AddWithValue("@p_CreatedBy", applicationUser != null ? applicationUser.ApplicationUserID : this.CreatedBy);
                command.Parameters.AddWithValue("@p_CreatedOn", this.CreatedOn);
                command.Parameters.AddWithValue("@p_UpdatedBy", ADOHelper.NullCheck(applicationUser != null ? applicationUser.ApplicationUserID : this.UpdatedBy));
                command.Parameters.AddWithValue("@p_UpdatedOn", ADOHelper.NullCheck(this.UpdatedOn));

                command.ExecuteNonQuery();

            // Update foreign keys values. This code will update the values passed in from the parent only if no errors occurred after executing the query.
            if(applicationUser != null && applicationUser.ApplicationUserID != this.CreatedBy)
                _createdByProperty= applicationUser.ApplicationUserID;

            // Update foreign keys values. This code will update the values passed in from the parent only if no errors occurred after executing the query.
            if(applicationUser != null && applicationUser.ApplicationUserID != this.UpdatedBy)
                _updatedByProperty= applicationUser.ApplicationUserID;

                // Update the original non-identity primary key value.
                _originalMailingTemplateIDProperty= this.MailingTemplateID;
            }
            
            // A child relationship exists on this Business Object but its type is not a child type (E.G. EditableChild). 
            // TODO: Please override OnChildInserted() and insert this child manually.
            // UpdateChildren(this, connection);

            OnChildInserted();
        }

        #endregion

        #region Child_Update

        /// <summary>
        /// Updates the corresponding record in the data base with the information in the current 
        ///    CSLA editable child business object of type <see cref="MailingTemplate"/> 
        /// </summary>
        /// <returns></returns>
        public void Child_Update(SqlConnection connection,SqlTransaction trans)
        {
            bool cancel = false;
            OnChildUpdating(connection, ref cancel,trans);
            if (cancel) return;

            if(connection.State != ConnectionState.Open) connection.Open();
            using(var command = new SqlCommand("[dbo].[spCFM_MailingTemplate_Update]", connection,trans))
            {
                command.CommandType = CommandType.StoredProcedure;
		
                command.Parameters.AddWithValue("@p_OriginalMailingTemplateID", this.OriginalMailingTemplateID);
                command.Parameters.AddWithValue("@p_MailingTemplateID", this.MailingTemplateID);
                command.Parameters.AddWithValue("@p_Description", ADOHelper.NullCheck(this.Description));
                command.Parameters.AddWithValue("@p_MailingText", ADOHelper.NullCheck(this.MailingText));
                command.Parameters.AddWithValue("@p_MailingSubject", ADOHelper.NullCheck(this.MailingSubject));
                command.Parameters.AddWithValue("@p_MailingFrom", ADOHelper.NullCheck(this.MailingFrom));
                command.Parameters.AddWithValue("@p_CreatedBy", this.CreatedBy);
                command.Parameters.AddWithValue("@p_CreatedOn", this.CreatedOn);
                command.Parameters.AddWithValue("@p_UpdatedBy", ADOHelper.NullCheck(this.UpdatedBy));
                command.Parameters.AddWithValue("@p_UpdatedOn", ADOHelper.NullCheck(this.UpdatedOn));

                //result: The number of rows changed, inserted, or deleted. -1 for select statements; 0 if no rows were affected, or the statement failed. 
                int result = command.ExecuteNonQuery();
                if (result == 0)
                    throw new DBConcurrencyException("The entity is out of date on the client. Please update the entity and try again. This could also be thrown if the sql statement failed to execute.");

                // Update non-identity primary key value.
                _mailingTemplateIDProperty=(System.Int32)command.Parameters["@p_MailingTemplateID"].Value;

                // Update non-identity primary key value.
                _originalMailingTemplateIDProperty= this.MailingTemplateID;
            }

            UpdateChildren(this, connection,trans);

            OnChildUpdated();
        }
 
        public void Child_Update(ApplicationUser applicationUser, SqlConnection connection,SqlTransaction trans)
        {
            bool cancel = false;
            OnChildUpdating(applicationUser, connection, ref cancel,trans);
            if (cancel) return;

            if(connection.State != ConnectionState.Open) connection.Open();
            using(var command = new SqlCommand("[dbo].[spCFM_MailingTemplate_Update]", connection,trans))
            {
                command.CommandType = CommandType.StoredProcedure;
		
                command.Parameters.AddWithValue("@p_OriginalMailingTemplateID", this.OriginalMailingTemplateID);
                command.Parameters.AddWithValue("@p_MailingTemplateID", this.MailingTemplateID);
                command.Parameters.AddWithValue("@p_Description", ADOHelper.NullCheck(this.Description));
                command.Parameters.AddWithValue("@p_MailingText", ADOHelper.NullCheck(this.MailingText));
                command.Parameters.AddWithValue("@p_MailingSubject", ADOHelper.NullCheck(this.MailingSubject));
                command.Parameters.AddWithValue("@p_MailingFrom", ADOHelper.NullCheck(this.MailingFrom));
                command.Parameters.AddWithValue("@p_CreatedBy", applicationUser != null ? applicationUser.ApplicationUserID : this.CreatedBy);
                command.Parameters.AddWithValue("@p_CreatedOn", this.CreatedOn);
                command.Parameters.AddWithValue("@p_UpdatedBy", ADOHelper.NullCheck(applicationUser != null ? applicationUser.ApplicationUserID : this.UpdatedBy));
                command.Parameters.AddWithValue("@p_UpdatedOn", ADOHelper.NullCheck(this.UpdatedOn));

                //result: The number of rows changed, inserted, or deleted. -1 for select statements; 0 if no rows were affected, or the statement failed. 
                int result = command.ExecuteNonQuery();
                if (result == 0)
                    throw new DBConcurrencyException("The entity is out of date on the client. Please update the entity and try again. This could also be thrown if the sql statement failed to execute.");

                // Update non-identity primary key value.
                _mailingTemplateIDProperty=(System.Int32)command.Parameters["@p_MailingTemplateID"].Value;

                // Update foreign keys values. This code will update the values passed in from the parent only if no errors occurred after executing the query.
                if(applicationUser != null && applicationUser.ApplicationUserID != this.CreatedBy)
                    _createdByProperty= applicationUser.ApplicationUserID;

                // Update foreign keys values. This code will update the values passed in from the parent only if no errors occurred after executing the query.
                if(applicationUser != null && applicationUser.ApplicationUserID != this.UpdatedBy)
                    _updatedByProperty= applicationUser.ApplicationUserID;

                // Update non-identity primary key value.
                _originalMailingTemplateIDProperty= this.MailingTemplateID;
            }
            
            // A child relationship exists on this Business Object but its type is not a child type (E.G. EditableChild). 
            // TODO: Please override OnChildUpdated() and update this child manually.
            // UpdateChildren(this, connection);

            OnChildUpdated();
        }
        #endregion

        /// <summary>
        /// Deletes the corresponding record in the data base with the information in the current 
        ///    CSLA editable child business object of type <see cref="MailingTemplate"/> 
        /// </summary>
        /// <returns></returns>
        private void Child_DeleteSelf(SqlConnection connection)
        {
            bool cancel = false;
            OnChildSelfDeleting(connection, ref cancel);
            if (cancel) return;
            
            //DataPortal_Delete(new MailingTemplateCriteria (MailingTemplateID), connection);
        
            OnChildSelfDeleted();
        }

        #region Map
		public void InitDTO()
		{
			  MailingTemplateDTO dt=new MailingTemplateDTO();
			dt.MailingTemplateID =this.MailingTemplateID ;
			dt.Description =this.Description ;
			dt.MailingText =this.MailingText ;
			dt.MailingSubject =this.MailingSubject ;
			dt.MailingFrom =this.MailingFrom ;
			dt.CreatedBy =this.CreatedBy ;
			dt.CreatedOn =this.CreatedOn ;
			dt.UpdatedBy =this.UpdatedBy ;
			dt.UpdatedOn =this.UpdatedOn ;
   //LoadProperty(_currentDto, dt);
  this.CurrentDTO = dt;

		}
		/*
        private void Map(SafeDataReader reader)
        {
            bool cancel = false;
            OnMapping(reader, ref cancel);
            if (cancel) return;

            using(BypassPropertyChecks)
            {
                LoadProperty(_mailingTemplateIDProperty, reader["MailingTemplateID"]);
                LoadProperty(_originalMailingTemplateIDProperty, reader["MailingTemplateID"]);
                LoadProperty(_descriptionProperty, reader["Description"]);
                LoadProperty(_mailingTextProperty, reader["MailingText"]);
                LoadProperty(_mailingSubjectProperty, reader["MailingSubject"]);
                LoadProperty(_mailingFromProperty, reader["MailingFrom"]);
                LoadProperty(_createdByProperty, reader["CreatedBy"]);
                LoadProperty(_createdOnProperty, reader["CreatedOn"]);
                LoadProperty(_updatedByProperty, reader["UpdatedBy"]);
                LoadProperty(_updatedOnProperty, reader["UpdatedOn"]);
            }	
			InitDTO();
            OnMapped();
        }
        
        private void Child_Fetch(SafeDataReader reader)
        {
            Map(reader);
        }
		*/

        #endregion
	}
}
 