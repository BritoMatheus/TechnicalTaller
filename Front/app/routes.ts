import { type RouteConfig, index, route, prefix } from "@react-router/dev/routes";

export default [
    index("routes/home/index.tsx"),
    route("employee-register", "./routes/employee-register/create.tsx"),
    route("employee-register-edit/:id", "./routes/employee-register/edit.tsx")
] satisfies RouteConfig;
