﻿//------------------------------------------------------------------------------
// <autogenerated>
//     
//     Changes to this file will be lost after each regeneration.
//     To extend the functionality of this class, please modify the partial class 'BankAccountCard.cs'.
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
	public partial class BankAccountCard
	{
    
		private BankAccountCard DataPortal_Fetch(BankAccountCardCriteria criteria)
		{
 
			bool cancel = false;
			OnFetching(criteria, ref cancel);
			if (cancel) return null;
			using (var connection = new SqlConnection(ADOHelper.ConnectionString))
			{
				connection.Open();
				using (var command = new SqlCommand("[dbo].[spCFM_BankAccountCard_Select]", connection))
				{
					command.CommandType = CommandType.StoredProcedure;
					command.Parameters.AddRange(ADOHelper.SqlParameters(criteria.StateBag));
                    command.Parameters.AddWithValue("@p_HeldByStaffIDHasValue", criteria.HeldByStaffIDHasValue);
                command.Parameters.AddWithValue("@p_HeldFromHasValue", criteria.HeldFromHasValue);
                command.Parameters.AddWithValue("@p_HeldToHasValue", criteria.HeldToHasValue);
                command.Parameters.AddWithValue("@p_UpdatedByHasValue", criteria.UpdatedByHasValue);
                command.Parameters.AddWithValue("@p_UpdatedOnHasValue", criteria.UpdatedOnHasValue);
					using(var reader = command.ExecuteReader())
					{
						var rowParser = reader.GetRowParser<BankAccountCard>();                       
						if(reader.Read())
						{
							return GetBankAccountCard(rowParser, reader);							
						}                            
						else
							throw new Exception(String.Format("The record was not found in 'dbo.BankAccountCard' using the following criteria: {0}.", criteria));
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
				
				using(var command = new SqlCommand("[dbo].[spCFM_BankAccountCard_Insert]", connection,trans))
				{
					command.CommandType = CommandType.StoredProcedure;
					
          command.Parameters.AddWithValue("@p_BankAccountCardID", this.BankAccountCardID);
                command.Parameters["@p_BankAccountCardID"].Direction = ParameterDirection.Output;
                command.Parameters.AddWithValue("@p_BankAccountID", this.BankAccountID);
                command.Parameters.AddWithValue("@p_CardNumber", this.CardNumber);
                command.Parameters.AddWithValue("@p_ExpDate", this.ExpDate);
                command.Parameters.AddWithValue("@p_HeldByStaffID", ADOHelper.NullCheck(this.HeldByStaffID));
                command.Parameters.AddWithValue("@p_HeldFrom", ADOHelper.NullCheck(this.HeldFrom));
                command.Parameters.AddWithValue("@p_HeldTo", ADOHelper.NullCheck(this.HeldTo));
                command.Parameters.AddWithValue("@p_IsActive", this.IsActive);
                command.Parameters.AddWithValue("@p_CreatedBy", this.CreatedBy);
                command.Parameters.AddWithValue("@p_CreatedOn", this.CreatedOn);
                command.Parameters.AddWithValue("@p_UpdatedBy", ADOHelper.NullCheck(this.UpdatedBy));
                command.Parameters.AddWithValue("@p_UpdatedOn", ADOHelper.NullCheck(this.UpdatedOn));
					command.ExecuteNonQuery();                  
					_bankAccountCardIDProperty=(System.Int32)command.Parameters["@p_BankAccountCardID"].Value;
                    
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
				using(var command = new SqlCommand("[dbo].[spCFM_BankAccountCard_Update]", connection,trans))
				{
					command.CommandType = CommandType.StoredProcedure;
					command.Parameters.AddWithValue("@p_BankAccountCardID", this.BankAccountCardID);
                command.Parameters.AddWithValue("@p_BankAccountID", this.BankAccountID);
                command.Parameters.AddWithValue("@p_CardNumber", this.CardNumber);
                command.Parameters.AddWithValue("@p_ExpDate", this.ExpDate);
                command.Parameters.AddWithValue("@p_HeldByStaffID", ADOHelper.NullCheck(this.HeldByStaffID));
                command.Parameters.AddWithValue("@p_HeldFrom", ADOHelper.NullCheck(this.HeldFrom));
                command.Parameters.AddWithValue("@p_HeldTo", ADOHelper.NullCheck(this.HeldTo));
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
		protected   void UpdateChildren(BankAccountCard parent,SqlConnection connection,SqlTransaction trans)
		{
		
		

		}

		protected   void DataPortal_DeleteSelf()
		{
			bool cancel = false;
			OnSelfDeleting(ref cancel);
			if (cancel) return;            
			DataPortal_Delete(new BankAccountCardCriteria (BankAccountCardID));        
			OnSelfDeleted();
		}
        
		//[Transactional(TransactionalTypes.TransactionScope)]
		protected void DataPortal_Delete(BankAccountCardCriteria criteria)
		{
            bool cancel = false;
            OnDeleting(criteria, ref cancel);
            if (cancel) return;

            using (var connection = new SqlConnection(ADOHelper.ConnectionString))
            {
                connection.Open();
                using (var command = new SqlCommand("[dbo].[spCFM_BankAccountCard_Delete]", connection))
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
        ///    CSLA editable child business object of type <see cref="BankAccountCard"/> 
        /// </summary>
        /// <returns></returns>
        public void Child_Insert(SqlConnection connection,SqlTransaction trans)
        {
            bool cancel = false;
            OnChildInserting(connection, ref cancel,trans);
            if (cancel) return;

            if(connection.State != ConnectionState.Open) connection.Open();
            using(var command = new SqlCommand("[dbo].[spCFM_BankAccountCard_Insert]", connection,trans))
            {
                command.CommandType = CommandType.StoredProcedure;
		
                command.Parameters.AddWithValue("@p_BankAccountCardID", this.BankAccountCardID);
                command.Parameters["@p_BankAccountCardID"].Direction = ParameterDirection.Output;
                command.Parameters.AddWithValue("@p_BankAccountID", this.BankAccountID);
                command.Parameters.AddWithValue("@p_CardNumber", this.CardNumber);
                command.Parameters.AddWithValue("@p_ExpDate", this.ExpDate);
                command.Parameters.AddWithValue("@p_HeldByStaffID", ADOHelper.NullCheck(this.HeldByStaffID));
                command.Parameters.AddWithValue("@p_HeldFrom", ADOHelper.NullCheck(this.HeldFrom));
                command.Parameters.AddWithValue("@p_HeldTo", ADOHelper.NullCheck(this.HeldTo));
                command.Parameters.AddWithValue("@p_IsActive", this.IsActive);
                command.Parameters.AddWithValue("@p_CreatedBy", this.CreatedBy);
                command.Parameters.AddWithValue("@p_CreatedOn", this.CreatedOn);
                command.Parameters.AddWithValue("@p_UpdatedBy", ADOHelper.NullCheck(this.UpdatedBy));
                command.Parameters.AddWithValue("@p_UpdatedOn", ADOHelper.NullCheck(this.UpdatedOn));

                command.ExecuteNonQuery();
               
                // Update identity primary key value.
                _bankAccountCardIDProperty=(System.Int32)command.Parameters["@p_BankAccountCardID"].Value;
            }

            UpdateChildren(this, connection,trans);

            OnChildInserted();
        }

        public void Child_Insert(ApplicationUser applicationUser, SqlConnection connection,SqlTransaction trans)
        {
            Child_Insert(applicationUser, null, connection,trans);
        }


        public void Child_Insert(BankAccount bankAccount, SqlConnection connection,SqlTransaction trans)
        {
            Child_Insert(null, bankAccount, connection,trans);
        }


        public void Child_Insert(ApplicationUser applicationUser, BankAccount bankAccount, SqlConnection connection,SqlTransaction trans)
        {
            bool cancel = false;
            OnChildInserting(applicationUser, bankAccount, connection, ref cancel,trans);
            if (cancel) return;

            if(connection.State != ConnectionState.Open) connection.Open();
            using(var command = new SqlCommand("[dbo].[spCFM_BankAccountCard_Insert]", connection,trans))
            {
                command.CommandType = CommandType.StoredProcedure;
		
                command.Parameters.AddWithValue("@p_BankAccountCardID", this.BankAccountCardID);
                command.Parameters["@p_BankAccountCardID"].Direction = ParameterDirection.Output;
                command.Parameters.AddWithValue("@p_BankAccountID", bankAccount != null ? bankAccount.BankAccountID : this.BankAccountID);
                command.Parameters.AddWithValue("@p_CardNumber", this.CardNumber);
                command.Parameters.AddWithValue("@p_ExpDate", this.ExpDate);
                command.Parameters.AddWithValue("@p_HeldByStaffID", ADOHelper.NullCheck(applicationUser != null ? applicationUser.ApplicationUserID : this.HeldByStaffID));
                command.Parameters.AddWithValue("@p_HeldFrom", ADOHelper.NullCheck(this.HeldFrom));
                command.Parameters.AddWithValue("@p_HeldTo", ADOHelper.NullCheck(this.HeldTo));
                command.Parameters.AddWithValue("@p_IsActive", this.IsActive);
                command.Parameters.AddWithValue("@p_CreatedBy", applicationUser != null ? applicationUser.ApplicationUserID : this.CreatedBy);
                command.Parameters.AddWithValue("@p_CreatedOn", this.CreatedOn);
                command.Parameters.AddWithValue("@p_UpdatedBy", ADOHelper.NullCheck(applicationUser != null ? applicationUser.ApplicationUserID : this.UpdatedBy));
                command.Parameters.AddWithValue("@p_UpdatedOn", ADOHelper.NullCheck(this.UpdatedOn));

                command.ExecuteNonQuery();
               
                // Update identity primary key value.
                _bankAccountCardIDProperty=(System.Int32)command.Parameters["@p_BankAccountCardID"].Value;

            // Update foreign keys values. This code will update the values passed in from the parent only if no errors occurred after executing the query.
            if(bankAccount != null && bankAccount.BankAccountID != this.BankAccountID)
                _bankAccountIDProperty= bankAccount.BankAccountID;

            // Update foreign keys values. This code will update the values passed in from the parent only if no errors occurred after executing the query.
            if(applicationUser != null && applicationUser.ApplicationUserID != this.HeldByStaffID)
                _heldByStaffIDProperty= applicationUser.ApplicationUserID;

            // Update foreign keys values. This code will update the values passed in from the parent only if no errors occurred after executing the query.
            if(applicationUser != null && applicationUser.ApplicationUserID != this.CreatedBy)
                _createdByProperty= applicationUser.ApplicationUserID;

            // Update foreign keys values. This code will update the values passed in from the parent only if no errors occurred after executing the query.
            if(applicationUser != null && applicationUser.ApplicationUserID != this.UpdatedBy)
                _updatedByProperty= applicationUser.ApplicationUserID;
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
        ///    CSLA editable child business object of type <see cref="BankAccountCard"/> 
        /// </summary>
        /// <returns></returns>
        public void Child_Update(SqlConnection connection,SqlTransaction trans)
        {
            bool cancel = false;
            OnChildUpdating(connection, ref cancel,trans);
            if (cancel) return;

            if(connection.State != ConnectionState.Open) connection.Open();
            using(var command = new SqlCommand("[dbo].[spCFM_BankAccountCard_Update]", connection,trans))
            {
                command.CommandType = CommandType.StoredProcedure;
		
                command.Parameters.AddWithValue("@p_BankAccountCardID", this.BankAccountCardID);
                command.Parameters.AddWithValue("@p_BankAccountID", this.BankAccountID);
                command.Parameters.AddWithValue("@p_CardNumber", this.CardNumber);
                command.Parameters.AddWithValue("@p_ExpDate", this.ExpDate);
                command.Parameters.AddWithValue("@p_HeldByStaffID", ADOHelper.NullCheck(this.HeldByStaffID));
                command.Parameters.AddWithValue("@p_HeldFrom", ADOHelper.NullCheck(this.HeldFrom));
                command.Parameters.AddWithValue("@p_HeldTo", ADOHelper.NullCheck(this.HeldTo));
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

        public void Child_Update(ApplicationUser applicationUser, SqlConnection connection,SqlTransaction trans)
        {
            Child_Update(applicationUser, null, connection,trans);
        }


        public void Child_Update(BankAccount bankAccount, SqlConnection connection,SqlTransaction trans)
        {
            Child_Update(null, bankAccount, connection,trans);
        }

 
        public void Child_Update(ApplicationUser applicationUser, BankAccount bankAccount, SqlConnection connection,SqlTransaction trans)
        {
            bool cancel = false;
            OnChildUpdating(applicationUser, bankAccount, connection, ref cancel,trans);
            if (cancel) return;

            if(connection.State != ConnectionState.Open) connection.Open();
            using(var command = new SqlCommand("[dbo].[spCFM_BankAccountCard_Update]", connection,trans))
            {
                command.CommandType = CommandType.StoredProcedure;
		
                command.Parameters.AddWithValue("@p_BankAccountCardID", this.BankAccountCardID);
                command.Parameters.AddWithValue("@p_BankAccountID", bankAccount != null ? bankAccount.BankAccountID : this.BankAccountID);
                command.Parameters.AddWithValue("@p_CardNumber", this.CardNumber);
                command.Parameters.AddWithValue("@p_ExpDate", this.ExpDate);
                command.Parameters.AddWithValue("@p_HeldByStaffID", ADOHelper.NullCheck(applicationUser != null ? applicationUser.ApplicationUserID : this.HeldByStaffID));
                command.Parameters.AddWithValue("@p_HeldFrom", ADOHelper.NullCheck(this.HeldFrom));
                command.Parameters.AddWithValue("@p_HeldTo", ADOHelper.NullCheck(this.HeldTo));
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
                if(bankAccount != null && bankAccount.BankAccountID != this.BankAccountID)
                    _bankAccountIDProperty= bankAccount.BankAccountID;

                // Update foreign keys values. This code will update the values passed in from the parent only if no errors occurred after executing the query.
                if(applicationUser != null && applicationUser.ApplicationUserID != this.HeldByStaffID)
                    _heldByStaffIDProperty= applicationUser.ApplicationUserID;

                // Update foreign keys values. This code will update the values passed in from the parent only if no errors occurred after executing the query.
                if(applicationUser != null && applicationUser.ApplicationUserID != this.CreatedBy)
                    _createdByProperty= applicationUser.ApplicationUserID;

                // Update foreign keys values. This code will update the values passed in from the parent only if no errors occurred after executing the query.
                if(applicationUser != null && applicationUser.ApplicationUserID != this.UpdatedBy)
                    _updatedByProperty= applicationUser.ApplicationUserID;
            }
            
            // A child relationship exists on this Business Object but its type is not a child type (E.G. EditableChild). 
            // TODO: Please override OnChildUpdated() and update this child manually.
            // UpdateChildren(this, connection);

            OnChildUpdated();
        }
        #endregion

        /// <summary>
        /// Deletes the corresponding record in the data base with the information in the current 
        ///    CSLA editable child business object of type <see cref="BankAccountCard"/> 
        /// </summary>
        /// <returns></returns>
        private void Child_DeleteSelf(SqlConnection connection)
        {
            bool cancel = false;
            OnChildSelfDeleting(connection, ref cancel);
            if (cancel) return;
            
            //DataPortal_Delete(new BankAccountCardCriteria (BankAccountCardID), connection);
        
            OnChildSelfDeleted();
        }

        #region Map
		public void InitDTO()
		{
			  BankAccountCardDTO dt=new BankAccountCardDTO();
			dt.BankAccountCardID =this.BankAccountCardID ;
			dt.BankAccountID =this.BankAccountID ;
			dt.CardNumber =this.CardNumber ;
			dt.ExpDate =this.ExpDate ;
			dt.HeldByStaffID =this.HeldByStaffID ;
			dt.HeldFrom =this.HeldFrom ;
			dt.HeldTo =this.HeldTo ;
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
                LoadProperty(_bankAccountCardIDProperty, reader["BankAccountCardID"]);
                LoadProperty(_bankAccountIDProperty, reader["BankAccountID"]);
                LoadProperty(_cardNumberProperty, reader["CardNumber"]);
                LoadProperty(_expDateProperty, reader["ExpDate"]);
                LoadProperty(_heldByStaffIDProperty, reader["HeldByStaffID"]);
                LoadProperty(_heldFromProperty, reader["HeldFrom"]);
                LoadProperty(_heldToProperty, reader["HeldTo"]);
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
 