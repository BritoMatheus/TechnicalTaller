import React, { useEffect, useRef, useState } from 'react';
import { toast } from 'react-toastify';
import Swal from 'sweetalert2';

import EmployeeService from '../../services/EmployeeService';
import type { Employee } from '../../types/Employee';
import Table from './Table';

const List = () => {

    const [data, setData] = useState<Employee[]>([]);
    const [loading, setLoading] = useState(true);

    useEffect(() => {
        get();
    }, []);

    const get = () => {
        EmployeeService.get().then(
            _data => {
                setData(_data.data);
                setLoading(false);
            }, error => {
                setLoading(false);
                toast.error('There was a problem retrieving the employees.');
            });
    }

    const handleDelete = (id: number) => {
        Swal.fire({
            title: 'Tem certeza que deseja excluir?',
            showCancelButton: true,
            confirmButtonText: 'Excluir',
            cancelButtonText: `Cancelar`,
        }).then((result) => {
            if (result.isConfirmed) {
                setLoading(true);
                EmployeeService.delete(id).then(
                    () => {
                        setLoading(false);
                        toast.success('Employee successfully deleted!');
                        get();
                    }, () => {
                        setLoading(false);
                        toast.error('An error occurred while deleting');
                    })
            }
        })
    }
    
    return (
        <Table
            data={data}
            onDelete={handleDelete}
        />
    );
};

export default List;