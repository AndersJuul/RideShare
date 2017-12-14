﻿using System;
using Ajf.RideShare.Api.UnitOfWork;

namespace TripGallery.API.UnitOfWork
{

    public class UnitOfWorkResult<T> where T : class
    {
        public T Result { get; private set; }

        public bool HasError
        {
            get
            {
                return Status != UnitOfWorkStatus.Ok;
            }
        }

        public UnitOfWorkStatus Status { get; private set; }

        public Exception Exception { get; private set; }


        public UnitOfWorkResult(T result, UnitOfWorkStatus status)
        {
            Result = result;
            Status = status;
        }


        public UnitOfWorkResult(T result, UnitOfWorkStatus status, Exception exception)
            : this(result, status)
        {
            Exception = exception;
        }


    }



    public class UnitOfWorkResult
    {

        public bool HasError
        {
            get
            {
                return Status != UnitOfWorkStatus.Ok;
            }
        }

        public UnitOfWorkStatus Status { get; private set; }

        public Exception Exception { get; private set; }


        public UnitOfWorkResult(UnitOfWorkStatus status)
        {
            Status = status;
        }


        public UnitOfWorkResult(UnitOfWorkStatus status, Exception exception)
            : this(status)
        {
            Exception = exception;
        }


    }

}
