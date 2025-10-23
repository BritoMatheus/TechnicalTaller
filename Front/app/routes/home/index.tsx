import { useNavigate } from "react-router";
import List from "./List"



const Home = () => {
    let navigate = useNavigate();

    const handleNew = () => {
        navigate(`/employee-register`);
    }

    return (
        <div className="container">
            <div className="flex" style={{ 
                justifyContent: 'space-between', 
                alignItems: 'center',
                marginBottom: 'var(--spacing-lg)',
                paddingBottom: 'var(--spacing-sm)',
                borderBottom: '1px solid var(--border-color)'
            }}>
                <h1>Employees</h1>
                <button 
                    className="btn btn-primary" 
                    onClick={() => handleNew()}
                    style={{
                        display: 'flex',
                        alignItems: 'center',
                        gap: 'var(--spacing-xs)'
                    }}
                >
                    <span>+</span>
                    <span>New Employee</span>
                </button>
            </div>
            <div className="card">
                <List />
            </div>
        </div>
    )
}

export default Home