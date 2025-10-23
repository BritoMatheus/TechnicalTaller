import axios from 'axios';

const responseSuccessInterceptor = async (response: any) => response?.data;

const BaseApi = axios.create({
  baseURL: "https://localhost:44325/",
  headers: {
    'Content-Type': 'application/json',
  },
});

BaseApi.interceptors.response.use(responseSuccessInterceptor);

export default BaseApi;