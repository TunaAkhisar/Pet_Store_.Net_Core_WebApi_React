import React from "react";
import Navbar from "./components/navbar/Navbar";
import { Route, Routes } from "react-router-dom";
import Home from "./pages/home/Home";
import Products from "./pages/products/Products";
import AddProduct from "./pages/add-product/AddProduct";
import DeleteProduct from "./pages/delete-product/DeleteProduct";
import EditProduct from "./pages/edit-product/EditProduct";

const App = () => {
  return (
    <div>
      <Navbar />
      <div className="wrapper">
        <Routes>
          <Route path="/" element={<Home />} />
          <Route path="/products">
            <Route index element={<Products />}></Route>
            <Route path="add" element={<AddProduct />}></Route>
            <Route path="delete/:id" element={<DeleteProduct />}></Route>
            <Route path="edit/:id" element={<EditProduct />}></Route>
          </Route>
        </Routes>
      </div>
    </div>
  );
};

export default App;
