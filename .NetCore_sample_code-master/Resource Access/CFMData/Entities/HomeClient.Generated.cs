﻿//------------------------------------------------------------------------------
// <autogenerated>
//     
//     Changes to this file will be lost after each regeneration.
//     To extend the functionality of this class, please modify the partial class 'HomeClient.cs'.
//
//     Template path: EditableRoot.Generated.cst
//     
// </autogenerated>
//------------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace CFMData
{
    [Serializable]
    public partial class HomeClient 
    {
        #region Contructor(s)

        public HomeClient()
        { /* Require use of factory methods */ }

        #endregion

			public HomeClient  Save()
      {
        if (this.IsNew)
        {
            DataPortal_Insert();
			this.IsNew=false;
        }
        else
        {
            DataPortal_Update();
        }

        return this;
      }
	  
			public bool IsDirty=false;
			public bool IsNew=true;
			#region Properties
		
			private HomeClientDTO _currentDto = null;
			public HomeClientDTO CurrentDTO
			{
				get { return _currentDto; }
				set { _currentDto = value; }
			}

			private System.Int32 _homeClientIDProperty  ;
			public System.Int32 HomeClientID
			{
				get { return _homeClientIDProperty; }
				set
				{ 
                 
					if (_homeClientIDProperty != value){
						IsDirty = true;
					}
					_homeClientIDProperty=value; 
				}
			}

			private System.Int32 _homeIDProperty  ;
			public System.Int32 HomeID
			{
				get { return _homeIDProperty; }
				set
				{ 
                 
					if (_homeIDProperty != value){
						IsDirty = true;
					}
					_homeIDProperty=value; 
				}
			}

			private System.Int32 _clientIDProperty  ;
			public System.Int32 ClientID
			{
				get { return _clientIDProperty; }
				set
				{ 
                 
					if (_clientIDProperty != value){
						IsDirty = true;
					}
					_clientIDProperty=value; 
				}
			}

			private System.DateTime _entryDateProperty  ;
			public System.DateTime EntryDate
			{
				get { return _entryDateProperty; }
				set
				{ 
                 
					if (_entryDateProperty != value){
						IsDirty = true;
					}
					_entryDateProperty=value; 
				}
			}

			private System.DateTime? _exitDateProperty  = null;
			public System.DateTime? ExitDate
			{
				get { return _exitDateProperty; }
				set
				{ 
                 
					if (_exitDateProperty != value){
						IsDirty = true;
					}
					_exitDateProperty=value; 
				}
			}

			private System.Boolean _isActiveProperty  ;
			public System.Boolean IsActive
			{
				get { return _isActiveProperty; }
				set
				{ 
                 
					if (_isActiveProperty != value){
						IsDirty = true;
					}
					_isActiveProperty=value; 
				}
			}

			private System.Int32 _createdByProperty  ;
			public System.Int32 CreatedBy
			{
				get { return _createdByProperty; }
				set
				{ 
                 
					if (_createdByProperty != value){
						IsDirty = true;
					}
					_createdByProperty=value; 
				}
			}

			private System.DateTime _createdOnProperty  ;
			public System.DateTime CreatedOn
			{
				get { return _createdOnProperty; }
				set
				{ 
                 
					if (_createdOnProperty != value){
						IsDirty = true;
					}
					_createdOnProperty=value; 
				}
			}

			private System.Int32? _updatedByProperty  = null;
			public System.Int32? UpdatedBy
			{
				get { return _updatedByProperty; }
				set
				{ 
                 
					if (_updatedByProperty != value){
						IsDirty = true;
					}
					_updatedByProperty=value; 
				}
			}

			private System.DateTime? _updatedOnProperty  = null;
			public System.DateTime? UpdatedOn
			{
				get { return _updatedOnProperty; }
				set
				{ 
                 
					if (_updatedOnProperty != value){
						IsDirty = true;
					}
					_updatedOnProperty=value; 
				}
			}

			// ManyToOne
			private bool _createdByApplicationUserPropertyChecked = false;
			private ApplicationUser _createdByApplicationUserProperty = null;
			public ApplicationUser CreatedByApplicationUser
			{
				get
				{
					if(!_createdByApplicationUserPropertyChecked)
					{						
						var criteria = new CFMData.ApplicationUserCriteria {ApplicationUserID = CreatedBy};
						
						_createdByApplicationUserPropertyChecked=true;                       
						_createdByApplicationUserProperty= CFMData.ApplicationUser.GetByApplicationUserID(CreatedBy);
					}                
					return _createdByApplicationUserProperty;
				}
			}

			// ManyToOne
			private bool _clientPropertyChecked = false;
			private Client _clientProperty = null;
			public Client Client
			{
				get
				{
					if(!_clientPropertyChecked)
					{						
						var criteria = new CFMData.ClientCriteria {ClientID = ClientID};
						
						_clientPropertyChecked=true;                       
						_clientProperty= CFMData.Client.GetByClientID(ClientID);
					}                
					return _clientProperty;
				}
			}

			// ManyToOne
			private bool _homePropertyChecked = false;
			private Home _homeProperty = null;
			public Home Home
			{
				get
				{
					if(!_homePropertyChecked)
					{						
						var criteria = new CFMData.HomeCriteria {HomeID = HomeID};
						
						_homePropertyChecked=true;                       
						_homeProperty= CFMData.Home.GetByHomeID(HomeID);
					}                
					return _homeProperty;
				}
			}

			// ManyToZeroOrOne
			private bool _updatedByApplicationUserPropertyChecked = false;
			private ApplicationUser _updatedByApplicationUserProperty = null;
			public ApplicationUser UpdatedByApplicationUser
			{
				get
				{
                    if(!UpdatedBy.HasValue) 
					return null;

					if(!_updatedByApplicationUserPropertyChecked)
					{						
						var criteria = new CFMData.ApplicationUserCriteria {};
						if(UpdatedBy.HasValue) criteria.ApplicationUserID = UpdatedBy.Value;
						_updatedByApplicationUserPropertyChecked=true;                       
						_updatedByApplicationUserProperty= CFMData.ApplicationUser.GetByApplicationUserID(UpdatedBy.Value);
					}                
					return _updatedByApplicationUserProperty;
				}
			}

			// OneToMany
			//PropertyInfo<BudgetClientAdjustmentList>
			private bool _budgetClientAdjustmentsPropertyChecked = false;
			private BudgetClientAdjustmentList _budgetClientAdjustmentsProperty = null;
			public BudgetClientAdjustmentList BudgetClientAdjustments
			{
				get
				{
					if(!_budgetClientAdjustmentsPropertyChecked )
					{
						_budgetClientAdjustmentsPropertyChecked =true; 
						var criteria = new CFMData.BudgetClientAdjustmentCriteria {HomeClientID = HomeClientID};
						                        
						_budgetClientAdjustmentsProperty= CFMData.BudgetClientAdjustmentList.GetByHomeClientID(HomeClientID);
 
					}
					return _budgetClientAdjustmentsProperty;
				}
			}


        #endregion
		public bool IsChildDirty()
		{
		
		
			 
			if(_budgetClientAdjustmentsPropertyChecked)
			{
					if(_budgetClientAdjustmentsProperty != null)
					{
						foreach (BudgetClientAdjustment childObj in _budgetClientAdjustmentsProperty)
                        {
                            if (childObj.IsDirty || childObj.IsChildDirty())
                            {
                                return true;
                            }
                        }
					}
			}
			 
 



			return false;
		}

        #region Synchronous Factory Methods 

        /// <summary>
        /// Creates a new object of type <see cref="HomeClient"/>. 
        /// </summary>
        /// <returns>Returns a newly instantiated collection of type <see cref="HomeClient"/>.</returns>    
        public static HomeClient NewHomeClient()
        {
            HomeClient obj=new HomeClient();

            return obj;
        }

			public static HomeClient GetHomeClient(Func<IDataReader, HomeClient> rowParser,SqlDataReader reader)
			{
				HomeClient obj = rowParser(reader);
				obj.InitDTO();					
				obj.IsDirty = false;
				obj.IsNew = false;
				return obj;
			}
        
 

        /// <summary>
        /// Returns a <see cref="HomeClient"/> object of the specified criteria. 
        /// </summary>
        /// <param name="homeClientID">No additional detail available.</param>
        /// <returns>A <see cref="HomeClient"/> object of the specified criteria.</returns>
        public static HomeClient GetByHomeClientID(System.Int32 homeClientID)
        {
            var criteria = new HomeClientCriteria {HomeClientID = homeClientID};
            
            
          return  new HomeClient().DataPortal_Fetch(criteria);
           
        }

        /// <summary>
        /// Returns a <see cref="HomeClient"/> object of the specified criteria. 
        /// </summary>
        /// <param name="createdBy">No additional detail available.</param>
        /// <returns>A <see cref="HomeClient"/> object of the specified criteria.</returns>
        public static HomeClient GetByCreatedBy(System.Int32 createdBy)
        {
            var criteria = new HomeClientCriteria {CreatedBy = createdBy};
            
            
          return  new HomeClient().DataPortal_Fetch(criteria);
           
        }

        /// <summary>
        /// Returns a <see cref="HomeClient"/> object of the specified criteria. 
        /// </summary>
        /// <param name="clientID">No additional detail available.</param>
        /// <returns>A <see cref="HomeClient"/> object of the specified criteria.</returns>
        public static HomeClient GetByClientID(System.Int32 clientID)
        {
            var criteria = new HomeClientCriteria {ClientID = clientID};
            
            
          return  new HomeClient().DataPortal_Fetch(criteria);
           
        }

        /// <summary>
        /// Returns a <see cref="HomeClient"/> object of the specified criteria. 
        /// </summary>
        /// <param name="homeID">No additional detail available.</param>
        /// <returns>A <see cref="HomeClient"/> object of the specified criteria.</returns>
        public static HomeClient GetByHomeID(System.Int32 homeID)
        {
            var criteria = new HomeClientCriteria {HomeID = homeID};
            
            
          return  new HomeClient().DataPortal_Fetch(criteria);
           
        }

        /// <summary>
        /// Returns a <see cref="HomeClient"/> object of the specified criteria. 
        /// </summary>
        /// <param name="updatedBy">No additional detail available.</param>
        /// <returns>A <see cref="HomeClient"/> object of the specified criteria.</returns>
        public static HomeClient GetByUpdatedBy(System.Int32? updatedBy)
        {
            var criteria = new HomeClientCriteria {};
                            if(updatedBy.HasValue) criteria.UpdatedBy = updatedBy.Value;
            
          return  new HomeClient().DataPortal_Fetch(criteria);
           
        }

        public static void DeleteHomeClient(System.Int32 homeClientID)
        {
            var criteria = new HomeClientCriteria {HomeClientID = homeClientID};
            
            
             new HomeClient().DataPortal_Delete(criteria);
        }

        #endregion
 

        #region DataPortal partial methods

        /// <summary>
        /// CodeSmith generated stub method that is called when creating the <see cref="HomeClient"/> object. 
        /// </summary>
        /// <param name="cancel">Value returned from the method indicating whether the object creation should proceed.</param>
        partial void OnCreating(ref bool cancel);

        /// <summary>
        /// CodeSmith generated stub method that is called after the <see cref="HomeClient"/> object has been created. 
        /// </summary>
        partial void OnCreated();

        /// <summary>
        /// CodeSmith generated stub method that is called when fetching the <see cref="HomeClient"/> object. 
        /// </summary>
        /// <param name="criteria"><see cref="HomeClientCriteria"/> object containing the criteria of the object to fetch.</param>
        /// <param name="cancel">Value returned from the method indicating whether the object fetching should proceed.</param>
        partial void OnFetching(HomeClientCriteria criteria, ref bool cancel);

        /// <summary>
        /// CodeSmith generated stub method that is called after the <see cref="HomeClient"/> object has been fetched. 
        /// </summary>    
        partial void OnFetched();

        /// <summary>
        /// CodeSmith generated stub method that is called when mapping the <see cref="HomeClient"/> object. 
        /// </summary>
        /// <param name="cancel">Value returned from the method indicating whether the object mapping should proceed.</param>
        partial void OnMapping(ref bool cancel);
 
        /// <summary>
        /// CodeSmith generated stub method that is called when mapping the <see cref="HomeClient"/> object. 
        /// </summary>
        /// <param name="reader"></param>
        /// <param name="cancel">Value returned from the method indicating whether the object mapping should proceed.</param>
        //partial void OnMapping(SafeDataReader reader, ref bool cancel);

        /// <summary>
        /// CodeSmith generated stub method that is called after the <see cref="HomeClient"/> object has been mapped. 
        /// </summary>
        partial void OnMapped();

        /// <summary>
        /// CodeSmith generated stub method that is called when inserting the <see cref="HomeClient"/> object. 
        /// </summary>
        /// <param name="cancel">Value returned from the method indicating whether the object insertion should proceed.</param>
        partial void OnInserting(ref bool cancel);

        /// <summary>
        /// CodeSmith generated stub method that is called after the <see cref="HomeClient"/> object has been inserted. 
        /// </summary>
        partial void OnInserted();

        /// <summary>
        /// CodeSmith generated stub method that is called when updating the <see cref="HomeClient"/> object. 
        /// </summary>
        /// <param name="cancel">Value returned from the method indicating whether the object creation should proceed.</param>
        partial void OnUpdating(ref bool cancel);

        /// <summary>
        /// CodeSmith generated stub method that is called after the <see cref="HomeClient"/> object has been updated. 
        /// </summary>
        partial void OnUpdated();

        /// <summary>
        /// CodeSmith generated stub method that is called when self deleting the <see cref="HomeClient"/> object. 
        /// </summary>
        /// <param name="cancel">Value returned from the method indicating whether the object self deletion should proceed.</param>
        partial void OnSelfDeleting(ref bool cancel);

        /// <summary>
        /// CodeSmith generated stub method that is called after the <see cref="HomeClient"/> object has been deleted. 
        /// </summary>
        partial void OnSelfDeleted();

        /// <summary>
        /// CodeSmith generated stub method that is called when deleting the <see cref="HomeClient"/> object. 
        /// </summary>
        /// <param name="criteria"><see cref="HomeClientCriteria"/> object containing the criteria of the object to delete.</param>
        /// <param name="cancel">Value returned from the method indicating whether the object deletion should proceed.</param>
        partial void OnDeleting(HomeClientCriteria criteria, ref bool cancel);

        /// <summary>
        /// CodeSmith generated stub method that is called after the <see cref="HomeClient"/> object with the specified criteria has been deleted. 
        /// </summary>
        partial void OnDeleted();
        //partial void OnChildLoading(Csla.Core.IPropertyInfo childProperty, ref bool cancel);

        #endregion
        #region ChildPortal partial methods

        /// <summary>
        /// CodeSmith generated stub method that is called when creating the child <see cref="HomeClient"/> object. 
        /// </summary>
        /// <param name="cancel">Value returned from the method indicating whether the object creation should proceed.</param>
        partial void OnChildCreating(ref bool cancel);

        /// <summary>
        /// CodeSmith generated stub method that is called after the child <see cref="HomeClient"/> object has been created. 
        /// </summary>
        partial void OnChildCreated();

        /// <summary>
        /// CodeSmith generated stub method that is called when fetching the child <see cref="HomeClient"/> object. 
        /// </summary>
        /// <param name="criteria"><see cref="HomeClientCriteria"/> object containing the criteria of the object to fetch.</param>
        /// <param name="cancel">Value returned from the method indicating whether the object fetching should proceed.</param>
        partial void OnChildFetching(HomeClientCriteria criteria, ref bool cancel);

        /// <summary>
        /// CodeSmith generated stub method that is called after the child <see cref="HomeClient"/> object has been fetched. 
        /// </summary>
        partial void OnChildFetched();

        /// <summary>
        /// CodeSmith generated stub method that is called when mapping the child <see cref="HomeClient"/> object. 
        /// </summary>
        /// <param name="cancel">Value returned from the method indicating whether the object mapping should proceed.</param>
        //partial void OnMapping(ref bool cancel);

        /// <summary>
        /// CodeSmith generated stub method that is called when mapping the child <see cref="HomeClient"/> object. 
        /// </summary>
        /// <param name="reader"></param>
        /// <param name="cancel">Value returned from the method indicating whether the object mapping should proceed.</param>
        //partial void OnMapping(SafeDataReader reader, ref bool cancel);

        /// <summary>
        /// CodeSmith generated stub method that is called after the child <see cref="HomeClient"/> object has been mapped. 
        /// </summary>
        //partial void OnMapped();

        /// <summary>
        /// CodeSmith generated stub method that is called when inserting the child <see cref="HomeClient"/> object. 
        /// </summary>
        /// <param name="cancel">Value returned from the method indicating whether the object insertion should proceed.</param>
        partial void OnChildInserting(ref bool cancel,SqlTransaction trans);

        /// <summary>
        /// CodeSmith generated stub method that is called when inserting the child <see cref="HomeClient"/> object. 
        /// </summary>
        /// <param name="connection"></param>
        /// <param name="cancel">Value returned from the method indicating whether the object insertion should proceed.</param>
        partial void OnChildInserting(SqlConnection connection, ref bool cancel,SqlTransaction trans);

        /// <summary>
        /// CodeSmith generated stub method that is called when inserting the child <see cref="HomeClient"/> object. 
        /// </summary>
        partial void OnChildInserting(ApplicationUser applicationUser, Client client, Home home, SqlConnection connection, ref bool cancel,SqlTransaction trans);

        /// <summary>
        /// CodeSmith generated stub method that is called after the child <see cref="HomeClient"/> object has been inserted. 
        /// </summary>
        partial void OnChildInserted();

        /// <summary>
        /// CodeSmith generated stub method that is called when updating the child <see cref="HomeClient"/> object. 
        /// </summary>
        /// <param name="cancel">Value returned from the method indicating whether the object creation should proceed.</param>
        partial void OnChildUpdating(ref bool cancel,SqlTransaction trans);

        /// <summary>
        /// CodeSmith generated stub method that is called when updating the child <see cref="HomeClient"/> object. 
        /// </summary>
        partial void OnChildUpdating(SqlConnection connection, ref bool cancel,SqlTransaction trans);

        /// <summary>
        /// CodeSmith generated stub method that is called when updating the child <see cref="HomeClient"/> object. 
        /// </summary>
        /// <param name="connection"></param>
        /// <param name="cancel">Value returned from the method indicating whether the object insertion should proceed.</param>
        partial void OnChildUpdating(ApplicationUser applicationUser, Client client, Home home, SqlConnection connection, ref bool cancel,SqlTransaction trans);

        /// <summary>
        /// CodeSmith generated stub method that is called after the child <see cref="HomeClient"/> object has been updated. 
        /// </summary>
        partial void OnChildUpdated();

        /// <summary>
        /// CodeSmith generated stub method that is called when self deleting the child <see cref="HomeClient"/> object. 
        /// </summary>
        /// <param name="cancel">Value returned from the method indicating whether the object self deletion should proceed.</param>
        partial void OnChildSelfDeleting(ref bool cancel);

        /// <summary>
        /// CodeSmith generated stub method that is called when self deleting the child <see cref="HomeClient"/> object. 
        /// </summary>
        /// <param name="connection"></param>
        /// <param name="cancel">Value returned from the method indicating whether the object self deletion should proceed.</param>
        partial void OnChildSelfDeleting(SqlConnection connection, ref bool cancel);

        /// <summary>
        /// CodeSmith generated stub method that is called after the child <see cref="HomeClient"/> object has been deleted. 
        /// </summary>
        partial void OnChildSelfDeleted();

        /// <summary>
        /// CodeSmith generated stub method that is called when deleting the child <see cref="HomeClient"/> object. 
        /// </summary>
        /// <param name="criteria"><see cref="HomeClientCriteria"/> object containing the criteria of the object to delete.</param>
        /// <param name="cancel">Value returned from the method indicating whether the object deletion should proceed.</param>
        //partial void OnDeleting(HomeClientCriteria criteria, ref bool cancel);
        /// <summary>
        /// CodeSmith generated stub method that is called when deleting the child <see cref="HomeClient"/> object. 
        /// </summary>
        /// <param name="criteria"><see cref="HomeClientCriteria"/> object containing the criteria of the object to delete.</param>
        /// <param name="connection"></param>
        /// <param name="cancel">Value returned from the method indicating whether the object deletion should proceed.</param>
        partial void OnDeleting(HomeClientCriteria criteria, SqlConnection connection, ref bool cancel);

        /// <summary>
        /// CodeSmith generated stub method that is called after the child <see cref="HomeClient"/> object with the specified criteria has been deleted. 
        /// </summary>
        //partial void OnDeleted();
        //partial void OnChildLoading(Csla.Core.IPropertyInfo childProperty, ref bool cancel);

        #endregion
   

        #region Exists Command

        /// <summary>
        /// Determines if a record exists in the HomeClient table in the database for the specified criteria. 
        /// </summary>
        /// <param name="criteria">The criteria parameter is an <see cref="HomeClient"/> object.</param>
        /// <returns>A boolean value of true is returned if a record is found.</returns>
        public static HomeClient Exists(HomeClientCriteria criteria)
        {
			try
			{
					
				return new HomeClient().DataPortal_Fetch(criteria);
			}
			catch(Exception ex)
			{
			}
			return null;
			
        }

        
        #endregion

    }
}