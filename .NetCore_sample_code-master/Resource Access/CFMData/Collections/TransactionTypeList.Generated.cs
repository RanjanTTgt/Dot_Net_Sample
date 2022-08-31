﻿//------------------------------------------------------------------------------
// <autogenerated>
//     
//     Changes to this file will be lost after each regeneration.
//     To extend the functionality of this class, please modify the partial class 'TransactionTypeList.cs'.
//
//     Template: EditableRootList.Generated.cst
//     
// </autogenerated>
//------------------------------------------------------------------------------
using System;
using System.Linq;
using System.Collections.Generic;
 
namespace CFMData
{
    [Serializable]
    public partial class TransactionTypeList : List< TransactionType>
    {    
        private List<TransactionTypeDTO> _currentDto =null; 
        public List<TransactionTypeDTO> CurrentDTO
        {
            get 
            {
                if (_currentDto==null)
                {
                    _currentDto=new List<TransactionTypeDTO>();
                    foreach (TransactionType entity in this)
                    {
                        _currentDto.Add(entity.CurrentDTO);
                    }
                }
                return _currentDto;
			}
            
        }
        #region Contructor(s)

        public TransactionTypeList()
        { 
       //     AllowNew = true;
        }

        #endregion

       

        #region Synchronous Factory Methods 

        /// <summary>
        /// Creates a new object of type <see cref="TransactionTypeList"/>. 
        /// </summary>
        /// <returns>Returns a newly instantiated collection of type <see cref="TransactionTypeList"/>.</returns>
        public static TransactionTypeList NewList()
        {
            return new TransactionTypeList();
        }      

        /// <summary>
        /// Returns a <see cref="TransactionTypeList"/> object of the specified criteria. 
        /// </summary>
        /// <param name="transactionTypeID">No additional detail available.</param>
        /// <returns>A <see cref="TransactionTypeList"/> object of the specified criteria.</returns>
        public static TransactionTypeList GetByTransactionTypeID(System.Int32 transactionTypeID)
        {
            var criteria = new TransactionTypeCriteria{TransactionTypeID = transactionTypeID};
            
            
          return  new TransactionTypeList().DataPortal_Fetch(criteria);
        }

        public static TransactionTypeList GetByCriteria(TransactionTypeCriteria criteria)
        {
          return  new TransactionTypeList().DataPortal_Fetch(criteria);
//            return DataPortal.Fetch<TransactionTypeList>(criteria);
        }

        public static TransactionTypeList GetAll()
        {
          return  new TransactionTypeList().DataPortal_Fetch(new TransactionTypeCriteria());
            //return DataPortal.Fetch<TransactionTypeList>(new TransactionTypeCriteria());
        }

        #endregion

        #region Asynchronous Factory Methods
     

     
 
        #endregion

        #region DataPortal partial methods

        /// <summary>
        /// CodeSmith generated stub method that is called when creating the child <see cref="TransactionType"/> object. 
        /// </summary>
        /// <param name="cancel">Value returned from the method indicating whether the object creation should proceed.</param>
        partial void OnCreating(ref bool cancel);

        /// <summary>
        /// CodeSmith generated stub method that is called after the child <see cref="TransactionType"/> object has been created. 
        /// </summary>
        partial void OnCreated();

        /// <summary>
        /// CodeSmith generated stub method that is called when fetching the child <see cref="TransactionType"/> object. 
        /// </summary>
        /// <param name="criteria"><see cref="TransactionTypeCriteria"/> object containing the criteria of the object to fetch.</param>
        /// <param name="cancel">Value returned from the method indicating whether the object fetching should proceed.</param>
        partial void OnFetching(TransactionTypeCriteria criteria, ref bool cancel);

        /// <summary>
        /// CodeSmith generated stub method that is called after the child <see cref="TransactionType"/> object has been fetched. 
        /// </summary>
        partial void OnFetched();

        /// <summary>
        /// CodeSmith generated stub method that is called when mapping the child <see cref="TransactionType"/> object. 
        /// </summary>
        /// <param name="cancel">Value returned from the method indicating whether the object mapping should proceed.</param>
        partial void OnMapping(ref bool cancel);

        /// <summary>
        /// CodeSmith generated stub method that is called when mapping the child <see cref="TransactionType"/> object. 
        /// </summary>
        /// <param name="reader"></param>
        /// <param name="cancel">Value returned from the method indicating whether the object mapping should proceed.</param>
        //partial void OnMapping(SafeDataReader reader, ref bool cancel);

        /// <summary>
        /// CodeSmith generated stub method that is called after the child <see cref="TransactionType"/> object has been mapped. 
        /// </summary>
        partial void OnMapped();

        /// <summary>
        /// CodeSmith generated stub method that is called when updating the <see cref="TransactionType"/> object. 
        /// </summary>
        /// <param name="cancel">Value returned from the method indicating whether the object creation should proceed.</param>
        partial void OnUpdating(ref bool cancel);

        /// <summary>
        /// CodeSmith generated stub method that is called after the <see cref="TransactionType"/> object has been updated. 
        /// </summary>
        partial void OnUpdated();
       // partial void OnAddNewCore(ref TransactionType item, ref bool cancel);

        #endregion

    }
}