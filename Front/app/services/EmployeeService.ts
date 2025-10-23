
import type { Employee } from '../types/Employee';
import BaseApi from './BaseAPi';

const baseUrl = '/v1/employees';

class EmployeeService {

    static post(request: any) {
        return BaseApi.post(`${baseUrl}`, request);
    }

    static put(request: any) {
        return BaseApi.put(`${baseUrl}`, request);
    }

    static delete(id: number) {
        return BaseApi.delete(`${baseUrl}/${id}`);
    }

    static get() {
        return BaseApi.get<Employee[]>(`${baseUrl}`);
    }

    static getById(id: number) {
        return BaseApi.get(`${baseUrl}/${id}`);
    }

}

export default EmployeeService;