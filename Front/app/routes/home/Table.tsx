import { useNavigate } from 'react-router';
         
import type { Employee } from "~/types/Employee";


interface IProps {
    data: Employee[],
    onDelete: (id: number) => void,
}


const Table = ({ data, onDelete }: IProps) => {
    let navigate = useNavigate();

    const handleEdit = (id: number) => {
         navigate(`/employee-register-edit/${id}`);
    }

     const edtTemplate = (employee: Employee) => {
        return <button className="btn btn-primary btn-sm" onClick={() => handleEdit(employee.id)}>Edit</button>;
    };

    const deleteTemplate = (employee: Employee) => {
        return <button className="btn btn-primary btn-sm" onClick={() => onDelete(employee.id)}>Delete</button>;
    };

    const actions = (employee: Employee) => {
        return (
            <>
                {edtTemplate(employee)}
                {deleteTemplate(employee)}
            </>
        );
    }

    return (
        <div className="table-container">
            <table className="table">
                <thead>
                    <tr>
                        <th>First Name</th>
                        <th>Last Name</th>
                        <th>Email</th>
                        <th>Position</th>
                        <th>Actions</th>
                    </tr>
                </thead>
                <tbody>
                    {data.map((employee) => (
                        <tr key={employee.id}>
                            <td>{employee.firstName}</td>
                            <td>{employee.lastName}</td>
                            <td>{employee.email}</td>
                            <td>{employee.position}</td>
                            <td>
                                <div className="table-actions">
                                    <button 
                                        className="action-button edit"
                                        onClick={() => handleEdit(employee.id)}>
                                        Edit
                                    </button>
                                    <button 
                                        className="action-button delete"
                                        onClick={() => onDelete(employee.id)}>
                                        Delete
                                    </button>
                                </div>
                            </td>
                        </tr>
                    ))}
                </tbody>
            </table>
        </div>
    )
}

export default Table;