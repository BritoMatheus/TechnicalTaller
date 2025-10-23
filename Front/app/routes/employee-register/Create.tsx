import Forms from "./Forms"
import Header from "./Header"


const EmployeeRegister = () => {
    return (
        <div className="container">
            <Header title={'New Employee'}></Header>
            <Forms />
        </div>
    )
}

export default EmployeeRegister