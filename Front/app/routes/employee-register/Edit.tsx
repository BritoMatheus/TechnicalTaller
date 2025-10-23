import { useEffect, useState } from "react";
import { useParams } from "react-router";
import { toast } from "react-toastify";

import EmployeeService from "~/services/EmployeeService";
import type { Employee } from "~/types/Employee";
import Forms from "./Forms";
import Header from "./Header";


const EmployeeRegister = () => {
    let { id } = useParams();

    const [data, setData] = useState<Employee | null>(null);
    const [loading, setLoading] = useState<boolean>(true);

    useEffect(() => {
        fetchData();
    }, []);

    const fetchData = async () => {
        EmployeeService.getById(Number(id)).then(
            _data => {
                setLoading(false);
                setData(_data.data);
            }, () => {
                setLoading(false);
                toast.error('An error occurred while fetching employee data.');
            });
    }

    return (
        <div className="container">
            <Header title={'Edit Employee'}></Header>
            {loading ? (
                <div className="card p-lg flex-center">
                    <p>Loading...</p>
                </div>
            ) : (
                data && <Forms defaultData={data} />
            )}
        </div>
    )
}

export default EmployeeRegister