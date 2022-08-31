﻿//------------------------------------------------------------------------------
// <autogenerated>
//     
//     Changes to this file will be lost after each regeneration.
//     To extend the functionality of this class, please modify the partial class 'FinAdministrator.cs'.
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
	public partial class FinAdministrator
	{
    
		private FinAdministrator DataPortal_Fetch(FinAdministratorCriteria criteria)
		{
 
			bool cancel = false;
			OnFetching(criteria, ref cancel);
			if (cancel) return null;
			using (var connection = new SqlConnection(ADOHelper.ConnectionString))
			{
				connection.Open();
				using (var command = new SqlCommand("[dbo].[spCFM_FinAdministrator_Select]", connection))
				{
					command.CommandType = CommandType.StoredProcedure;
					command.Parameters.AddRange(ADOHelper.SqlParameters(criteria.StateBag));
                    command.Parameters.AddWithValue("@p_NameHasValue", criteria.NameHasValue);
                command.Parameters.AddWithValue("@p_EmailHasValue", criteria.EmailHasValue);
                command.Parameters.AddWithValue("@p_AddressIDHasValue", criteria.AddressIDHasValue);
                command.Parameters.AddWithValue("@p_BankAccountIDHasValue", criteria.BankAccountIDHasValue);
                command.Parameters.AddWithValue("@p_UpdatedByHasValue", criteria.UpdatedByHasValue);
                command.Parameters.AddWithValue("@p_UpdatedOnHasValue", criteria.UpdatedOnHasValue);
					using(var reader = command.ExecuteReader())
					{
						var rowParser = reader.GetRowParser<FinAdministrator>();                       
						if(reader.Read())
						{
							return GetFinAdministrator(rowParser, reader);							
						}                            
						else
							throw new Exception(String.Format("The record was not found in 'dbo.FinAdministrator' using the following criteria: {0}.", criteria));
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
				
				using(var command = new SqlCommand("[dbo].[spCFM_FinAdministrator_Insert]", connection,trans))
				{
					command.CommandType = CommandType.StoredProcedure;
					
          command.Parameters.AddWithValue("@p_FinAdministratorID", this.FinAdministratorID);
                command.Parameters["@p_FinAdministratorID"].Direction = ParameterDirection.Output;
                command.Parameters.AddWithValue("@p_GLEntityID", this.GLEntityID);
                command.Parameters.AddWithValue("@p_Name", ADOHelper.NullCheck(this.Name));
                command.Parameters.AddWithValue("@p_isOrganisation", this.IsOrganisation);
                command.Parameters.AddWithValue("@p_Email", ADOHelper.NullCheck(this.Email));
                command.Parameters.AddWithValue("@p_AddressID", ADOHelper.NullCheck(this.AddressID));
                command.Parameters.AddWithValue("@p_HasDirectDebit", this.HasDirectDebit);
                command.Parameters.AddWithValue("@p_BankAccountID", ADOHelper.NullCheck(this.BankAccountID));
                command.Parameters.AddWithValue("@p_IsActive", this.IsActive);
                command.Parameters.AddWithValue("@p_CreatedBy", this.CreatedBy);
                command.Parameters.AddWithValue("@p_CreatedOn", this.CreatedOn);
                command.Parameters.AddWithValue("@p_UpdatedBy", ADOHelper.NullCheck(this.UpdatedBy));
                command.Parameters.AddWithValue("@p_UpdatedOn", ADOHelper.NullCheck(this.UpdatedOn));
					command.ExecuteNonQuery();                  
					_finAdministratorIDProperty=(System.Int32)command.Parameters["@p_FinAdministratorID"].Value;
                    
				}
                
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
			using (var connection = new SqlConnection(ADOHelper.ConnectionString))
			{
				connection.Open();
				SqlTransaction trans = connection.BeginTransaction();
				try
				{
				using(var command = new SqlCommand("[dbo].[spCFM_FinAdministrator_Update]", connection,trans))
				{
					command.CommandType = CommandType.StoredProcedure;
					command.Parameters.AddWithValue("@p_FinAdministratorID", this.FinAdministratorID);
                command.Parameters.AddWithValue("@p_GLEntityID", this.GLEntityID);
                command.Parameters.AddWithValue("@p_Name", ADOHelper.NullCheck(this.Name));
                command.Parameters.AddWithValue("@p_isOrganisation", this.IsOrganisation);
                command.Parameters.AddWithValue("@p_Email", ADOHelper.NullCheck(this.Email));
                command.Parameters.AddWithValue("@p_AddressID", ADOHelper.NullCheck(this.AddressID));
                command.Parameters.AddWithValue("@p_HasDirectDebit", this.HasDirectDebit);
                command.Parameters.AddWithValue("@p_BankAccountID", ADOHelper.NullCheck(this.BankAccountID));
                command.Parameters.AddWithValue("@p_IsActive", this.IsActive);
                command.Parameters.AddWithValue("@p_CreatedBy", this.CreatedBy);
                command.Parameters.AddWithValue("@p_CreatedOn", this.CreatedOn);
                command.Parameters.AddWithValue("@p_UpdatedBy", ADOHelper.NullCheck(this.UpdatedBy));
                command.Parameters.AddWithValue("@p_UpdatedOn", ADOHelper.NullCheck(this.UpdatedOn));
					//result: The number of rows changed, inserted, or deleted. -1 for select statements; 0 if no rows were affected, or the statement failed. 
					int result = command.ExecuteNonQuery();
					if (result == 0)
						throw new DBConcurrencyException("The entity is out of date on the client. Please update the entity and try again. This could also be thrown if the sql statement failed to execute.");

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
		protected   void UpdateChildren(FinAdministrator parent,SqlConnection connection,SqlTransaction trans)
		{
		
		
			
			if(_finAdministratorAppUsersPropertyChecked )
			{
				if(_finAdministratorAppUsersProperty!=null)
				{
				
					foreach (FinAdministratorAppUser obj in _finAdministratorAppUsersProperty)
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
			DataPortal_Delete(new FinAdministratorCriteria (FinAdministratorID));        
			OnSelfDeleted();
		}
        
		//[Transactional(TransactionalTypes.TransactionScope)]
		protected void DataPortal_Delete(FinAdministratorCriteria criteria)
		{
            bool cancel = false;
            OnDeleting(criteria, ref cancel);
            if (cancel) return;

            using (var connection = new SqlConnection(ADOHelper.ConnectionString))
            {
                connection.Open();
                using (var command = new SqlCommand("[dbo].[spCFM_FinAdministrator_Delete]", connection))
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
        ///    CSLA editable child business object of type <see cref="FinAdministrator"/> 
        /// </summary>
        /// <returns></returns>
        public void Child_Insert(SqlConnection connection,SqlTransaction trans)
        {
            bool cancel = false;
            OnChildInserting(connection, ref cancel,trans);
            if (cancel) return;

            if(connection.State != ConnectionState.Open) connection.Open();
            using(var command = new SqlCommand("[dbo].[spCFM_FinAdministrator_Insert]", connection,trans))
            {
                command.CommandType = CommandType.StoredProcedure;
		
                command.Parameters.AddWithValue("@p_FinAdministratorID", this.FinAdministratorID);
                command.Parameters["@p_FinAdministratorID"].Direction = ParameterDirection.Output;
                command.Parameters.AddWithValue("@p_GLEntityID", this.GLEntityID);
                command.Parameters.AddWithValue("@p_Name", ADOHelper.NullCheck(this.Name));
                command.Parameters.AddWithValue("@p_isOrganisation", this.IsOrganisation);
                command.Parameters.AddWithValue("@p_Email", ADOHelper.NullCheck(this.Email));
                command.Parameters.AddWithValue("@p_AddressID", ADOHelper.NullCheck(this.AddressID));
                command.Parameters.AddWithValue("@p_HasDirectDebit", this.HasDirectDebit);
                command.Parameters.AddWithValue("@p_BankAccountID", ADOHelper.NullCheck(this.BankAccountID));
                command.Parameters.AddWithValue("@p_IsActive", this.IsActive);
                command.Parameters.AddWithValue("@p_CreatedBy", this.CreatedBy);
                command.Parameters.AddWithValue("@p_CreatedOn", this.CreatedOn);
                command.Parameters.AddWithValue("@p_UpdatedBy", ADOHelper.NullCheck(this.UpdatedBy));
                command.Parameters.AddWithValue("@p_UpdatedOn", ADOHelper.NullCheck(this.UpdatedOn));

                command.ExecuteNonQuery();
               
                // Update identity primary key value.
                _finAdministratorIDProperty=(System.Int32)command.Parameters["@p_FinAdministratorID"].Value;
            }

            UpdateChildren(this, connection,trans);

            OnChildInserted();
        }

        public void Child_Insert(Address address, SqlConnection connection,SqlTransaction trans)
        {
            Child_Insert(address, null, null, null, connection,trans);
        }


        public void Child_Insert(ApplicationUser applicationUser, SqlConnection connection,SqlTransaction trans)
        {
            Child_Insert(null, applicationUser, null, null, connection,trans);
        }


        public void Child_Insert(BankAccount bankAccount, SqlConnection connection,SqlTransaction trans)
        {
            Child_Insert(null, null, bankAccount, null, connection,trans);
        }


        public void Child_Insert(GLEntity gLEntity, SqlConnection connection,SqlTransaction trans)
        {
            Child_Insert(null, null, null, gLEntity, connection,trans);
        }


        public void Child_Insert(Address address, ApplicationUser applicationUser, BankAccount bankAccount, GLEntity gLEntity, SqlConnection connection,SqlTransaction trans)
        {
            bool cancel = false;
            OnChildInserting(address, applicationUser, bankAccount, gLEntity, connection, ref cancel,trans);
            if (cancel) return;

            if(connection.State != ConnectionState.Open) connection.Open();
            using(var command = new SqlCommand("[dbo].[spCFM_FinAdministrator_Insert]", connection,trans))
            {
                command.CommandType = CommandType.StoredProcedure;
		
                command.Parameters.AddWithValue("@p_FinAdministratorID", this.FinAdministratorID);
                command.Parameters["@p_FinAdministratorID"].Direction = ParameterDirection.Output;
                command.Parameters.AddWithValue("@p_GLEntityID", gLEntity != null ? gLEntity.GLEntityID : this.GLEntityID);
                command.Parameters.AddWithValue("@p_Name", ADOHelper.NullCheck(this.Name));
                command.Parameters.AddWithValue("@p_isOrganisation", this.IsOrganisation);
                command.Parameters.AddWithValue("@p_Email", ADOHelper.NullCheck(this.Email));
                command.Parameters.AddWithValue("@p_AddressID", ADOHelper.NullCheck(address != null ? address.AddressID : this.AddressID));
                command.Parameters.AddWithValue("@p_HasDirectDebit", this.HasDirectDebit);
                command.Parameters.AddWithValue("@p_BankAccountID", ADOHelper.NullCheck(bankAccount != null ? bankAccount.BankAccountID : this.BankAccountID));
                command.Parameters.AddWithValue("@p_IsActive", this.IsActive);
                command.Parameters.AddWithValue("@p_CreatedBy", applicationUser != null ? applicationUser.ApplicationUserID : this.CreatedBy);
                command.Parameters.AddWithValue("@p_CreatedOn", this.CreatedOn);
                command.Parameters.AddWithValue("@p_UpdatedBy", ADOHelper.NullCheck(applicationUser != null ? applicationUser.ApplicationUserID : this.UpdatedBy));
                command.Parameters.AddWithValue("@p_UpdatedOn", ADOHelper.NullCheck(this.UpdatedOn));

                command.ExecuteNonQuery();
               
                // Update identity primary key value.
                _finAdministratorIDProperty=(System.Int32)command.Parameters["@p_FinAdministratorID"].Value;

            // Update foreign keys values. This code will update the values passed in from the parent only if no errors occurred after executing the query.
            if(gLEntity != null && gLEntity.GLEntityID != this.GLEntityID)
                _gLEntityIDProperty= gLEntity.GLEntityID;

            // Update foreign keys values. This code will update the values passed in from the parent only if no errors occurred after executing the query.
            if(address != null && address.AddressID != this.AddressID)
                _addressIDProperty= address.AddressID;

            // Update foreign keys values. This code will update the values passed in from the parent only if no errors occurred after executing the query.
            if(bankAccount != null && bankAccount.BankAccountID != this.BankAccountID)
                _bankAccountIDProperty= bankAccount.BankAccountID;

            // Update foreign keys values. This code will update the values passed in from the parent only if no errors occurred after executing the query.
            if(applicationUser != null && applicationUser.ApplicationUserID != this.CreatedBy)
                _createdByProperty= applicationUser.ApplicationUserID;

            // Update foreign keys values. This code will update the values passed in from the parent only if no errors occurred after executing the query.
            if(applicationUser != null && applicationUser.ApplicationUserID != this.UpdatedBy)
                _updatedByProperty= applicationUser.ApplicationUserID;
            }
            
            // A child relationship exists on this Business Object but its type is not a child type (E.G. EditableChild). 
            // TODO: Please override OnChildInserted() and insert this child manually.
            // UpdateChildren(this, null, connection);

            OnChildInserted();
        }

        #endregion

        #region Child_Update

        /// <summary>
        /// Updates the corresponding record in the data base with the information in the current 
        ///    CSLA editable child business object of type <see cref="FinAdministrator"/> 
        /// </summary>
        /// <returns></returns>
        public void Child_Update(SqlConnection connection,SqlTransaction trans)
        {
            bool cancel = false;
            OnChildUpdating(connection, ref cancel,trans);
            if (cancel) return;

            if(connection.State != ConnectionState.Open) connection.Open();
            using(var command = new SqlCommand("[dbo].[spCFM_FinAdministrator_Update]", connection,trans))
            {
                command.CommandType = CommandType.StoredProcedure;
		
                command.Parameters.AddWithValue("@p_FinAdministratorID", this.FinAdministratorID);
                command.Parameters.AddWithValue("@p_GLEntityID", this.GLEntityID);
                command.Parameters.AddWithValue("@p_Name", ADOHelper.NullCheck(this.Name));
                command.Parameters.AddWithValue("@p_isOrganisation", this.IsOrganisation);
                command.Parameters.AddWithValue("@p_Email", ADOHelper.NullCheck(this.Email));
                command.Parameters.AddWithValue("@p_AddressID", ADOHelper.NullCheck(this.AddressID));
                command.Parameters.AddWithValue("@p_HasDirectDebit", this.HasDirectDebit);
                command.Parameters.AddWithValue("@p_BankAccountID", ADOHelper.NullCheck(this.BankAccountID));
                command.Parameters.AddWithValue("@p_IsActive", this.IsActive);
                command.Parameters.AddWithValue("@p_CreatedBy", this.CreatedBy);
                command.Parameters.AddWithValue("@p_CreatedOn", this.CreatedOn);
                command.Parameters.AddWithValue("@p_UpdatedBy", ADOHelper.NullCheck(this.UpdatedBy));
                command.Parameters.AddWithValue("@p_UpdatedOn", ADOHelper.NullCheck(this.UpdatedOn));

                //result: The number of rows changed, inserted, or deleted. -1 for select statements; 0 if no rows were affected, or the statement failed. 
                int result = command.ExecuteNonQuery();
                if (result == 0)
                    throw new DBConcurrencyException("The entity is out of date on the client. Please update the entity and try again. This could also be thrown if the sql statement failed to execute.");
            }

            UpdateChildren(this, connection,trans);

            OnChildUpdated();
        }

        public void Child_Update(Address address, SqlConnection connection,SqlTransaction trans)
        {
            Child_Update(address, null, null, null, connection,trans);
        }


        public void Child_Update(ApplicationUser applicationUser, SqlConnection connection,SqlTransaction trans)
        {
            Child_Update(null, applicationUser, null, null, connection,trans);
        }


        public void Child_Update(BankAccount bankAccount, SqlConnection connection,SqlTransaction trans)
        {
            Child_Update(null, null, bankAccount, null, connection,trans);
        }


        public void Child_Update(GLEntity gLEntity, SqlConnection connection,SqlTransaction trans)
        {
            Child_Update(null, null, null, gLEntity, connection,trans);
        }

 
        public void Child_Update(Address address, ApplicationUser applicationUser, BankAccount bankAccount, GLEntity gLEntity, SqlConnection connection,SqlTransaction trans)
        {
            bool cancel = false;
            OnChildUpdating(address, applicationUser, bankAccount, gLEntity, connection, ref cancel,trans);
            if (cancel) return;

            if(connection.State != ConnectionState.Open) connection.Open();
            using(var command = new SqlCommand("[dbo].[spCFM_FinAdministrator_Update]", connection,trans))
            {
                command.CommandType = CommandType.StoredProcedure;
		
                command.Parameters.AddWithValue("@p_FinAdministratorID", this.FinAdministratorID);
                command.Parameters.AddWithValue("@p_GLEntityID", gLEntity != null ? gLEntity.GLEntityID : this.GLEntityID);
                command.Parameters.AddWithValue("@p_Name", ADOHelper.NullCheck(this.Name));
                command.Parameters.AddWithValue("@p_isOrganisation", this.IsOrganisation);
                command.Parameters.AddWithValue("@p_Email", ADOHelper.NullCheck(this.Email));
                command.Parameters.AddWithValue("@p_AddressID", ADOHelper.NullCheck(address != null ? address.AddressID : this.AddressID));
                command.Parameters.AddWithValue("@p_HasDirectDebit", this.HasDirectDebit);
                command.Parameters.AddWithValue("@p_BankAccountID", ADOHelper.NullCheck(bankAccount != null ? bankAccount.BankAccountID : this.BankAccountID));
                command.Parameters.AddWithValue("@p_IsActive", this.IsActive);
                command.Parameters.AddWithValue("@p_CreatedBy", applicationUser != null ? applicationUser.ApplicationUserID : this.CreatedBy);
                command.Parameters.AddWithValue("@p_CreatedOn", this.CreatedOn);
                command.Parameters.AddWithValue("@p_UpdatedBy", ADOHelper.NullCheck(applicationUser != null ? applicationUser.ApplicationUserID : this.UpdatedBy));
                command.Parameters.AddWithValue("@p_UpdatedOn", ADOHelper.NullCheck(this.UpdatedOn));

                //result: The number of rows changed, inserted, or deleted. -1 for select statements; 0 if no rows were affected, or the statement failed. 
                int result = command.ExecuteNonQuery();
                if (result == 0)
                    throw new DBConcurrencyException("The entity is out of date on the client. Please update the entity and try again. This could also be thrown if the sql statement failed to execute.");

                // Update foreign keys values. This code will update the values passed in from the parent only if no errors occurred after executing the query.
                if(gLEntity != null && gLEntity.GLEntityID != this.GLEntityID)
                    _gLEntityIDProperty= gLEntity.GLEntityID;

                // Update foreign keys values. This code will update the values passed in from the parent only if no errors occurred after executing the query.
                if(address != null && address.AddressID != this.AddressID)
                    _addressIDProperty= address.AddressID;

                // Update foreign keys values. This code will update the values passed in from the parent only if no errors occurred after executing the query.
                if(bankAccount != null && bankAccount.BankAccountID != this.BankAccountID)
                    _bankAccountIDProperty= bankAccount.BankAccountID;

                // Update foreign keys values. This code will update the values passed in from the parent only if no errors occurred after executing the query.
                if(applicationUser != null && applicationUser.ApplicationUserID != this.CreatedBy)
                    _createdByProperty= applicationUser.ApplicationUserID;

                // Update foreign keys values. This code will update the values passed in from the parent only if no errors occurred after executing the query.
                if(applicationUser != null && applicationUser.ApplicationUserID != this.UpdatedBy)
                    _updatedByProperty= applicationUser.ApplicationUserID;
            }
            
            // A child relationship exists on this Business Object but its type is not a child type (E.G. EditableChild). 
            // TODO: Please override OnChildUpdated() and update this child manually.
            // UpdateChildren(this, null, connection);

            OnChildUpdated();
        }
        #endregion

        /// <summary>
        /// Deletes the corresponding record in the data base with the information in the current 
        ///    CSLA editable child business object of type <see cref="FinAdministrator"/> 
        /// </summary>
        /// <returns></returns>
        private void Child_DeleteSelf(SqlConnection connection)
        {
            bool cancel = false;
            OnChildSelfDeleting(connection, ref cancel);
            if (cancel) return;
            
            //DataPortal_Delete(new FinAdministratorCriteria (FinAdministratorID), connection);
        
            OnChildSelfDeleted();
        }

        #region Map
		public void InitDTO()
		{
			  FinAdministratorDTO dt=new FinAdministratorDTO();
			dt.FinAdministratorID =this.FinAdministratorID ;
			dt.GLEntityID =this.GLEntityID ;
			dt.Name =this.Name ;
			dt.IsOrganisation =this.IsOrganisation ;
			dt.Email =this.Email ;
			dt.AddressID =this.AddressID ;
			dt.HasDirectDebit =this.HasDirectDebit ;
			dt.BankAccountID =this.BankAccountID ;
			dt.IsActive =this.IsActive ;
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
                LoadProperty(_finAdministratorIDProperty, reader["FinAdministratorID"]);
                LoadProperty(_gLEntityIDProperty, reader["GLEntityID"]);
                LoadProperty(_nameProperty, reader["Name"]);
                LoadProperty(_isOrganisationProperty, reader["isOrganisation"]);
                LoadProperty(_emailProperty, reader["Email"]);
                LoadProperty(_addressIDProperty, reader["AddressID"]);
                LoadProperty(_hasDirectDebitProperty, reader["HasDirectDebit"]);
                LoadProperty(_bankAccountIDProperty, reader["BankAccountID"]);
                LoadProperty(_isActiveProperty, reader["IsActive"]);
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
 