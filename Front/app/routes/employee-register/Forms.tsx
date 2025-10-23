import React, { useEffect, useRef, useState } from 'react';
import { useForm, type SubmitHandler } from "react-hook-form"
import { useNavigate } from 'react-router';
import { toast } from 'react-toastify';
import EmployeeService from '~/services/EmployeeService';
import type { Employee } from '~/types/Employee';

type Inputs = {
    firstName: string;
    lastName: string;
    email: string;
    position: string;
}

interface IProps {
    defaultData?: Employee | null;
}

const Forms = ({ defaultData }: IProps) => {
    let navigate = useNavigate();

    const {
        register,
        handleSubmit,
        formState: { errors },
    } = useForm<Inputs>()

    const [loading, setLoading] = useState(false);

    const onSubmit: SubmitHandler<Inputs> = (data) => {
        setLoading(true);
        const request = !defaultData ? EmployeeService.post : EmployeeService.put;

        request({ ...data, id: defaultData?.id }).then(
            () => {
                toast.success('Employee saved!');
                navigate('/');
            }, () => {
                setLoading(false);
                toast.error('Ocorreu um problema ao salvar!');
            });
    }

    return (
        <form onSubmit={handleSubmit(onSubmit)} className="card p-lg">
            <div className="grid" style={{ gridTemplateColumns: 'repeat(2, 1fr)', gap: 'var(--spacing-lg)' }}>
                <div className="form-group">
                    <label>First Name</label>
                    <input 
                        className="input"
                        defaultValue={defaultData?.firstName} 
                        {...register("firstName", { required: true, minLength: 4 })} 
                    />
                    {errors.firstName && (
                        <span className="error-text">This field is required</span>
                    )}
                </div>
                <div className="form-group">
                    <label>Last Name</label>
                    <input 
                        className="input"
                        defaultValue={defaultData?.lastName} 
                        {...register("lastName", { required: true, minLength: 4 })} 
                    />
                    {errors.lastName && (
                        <span className="error-text">This field is required</span>
                    )}
                </div>
                <div className="form-group">
                    <label>Email</label>
                    <input 
                        className="input"
                        type="email"
                        defaultValue={defaultData?.email} 
                        {...register("email", { required: true, minLength: 4 })} 
                    />
                    {errors.email && (
                        <span className="error-text">This field is required</span>
                    )}
                </div>
                <div className="form-group">
                    <label>Position</label>
                    <input 
                        className="input"
                        defaultValue={defaultData?.position} 
                        {...register("position", { required: true, minLength: 4 })} 
                    />
                    {errors.position && (
                        <span className="error-text">This field is required</span>
                    )}
                </div>
            </div>

            <div className="flex" style={{ justifyContent: 'flex-end', marginTop: 'var(--spacing-xl)' }}>
                <button 
                    className={`btn ${loading ? 'btn-secondary' : 'btn-primary'}`}
                    type="submit"
                    disabled={loading}
                >
                    {loading ? 'Saving...' : 'Save'}
                </button>
            </div>
        </form>
    );
};

export default Forms;