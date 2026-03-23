import axios from "axios";

const api = axios.create({
  baseURL: "https://localhost:44395/api", 
});

export const registerUser = (data) =>
  api.post("/auth/register", data);

export const loginUser = (data) =>
  api.post("/auth/login", data);

export const getUserDetails = (token) =>
  api.get("/auth/GetUser", {
    headers: {
      Authorization: `Bearer ${token}`,
    },
  });