import React, { ChangeEvent, useEffect, useState } from "react";
import { IProduct } from "../../type/global.typing";
import "./deleteProducts.scss";
import { useNavigate, useParams } from "react-router-dom";
import { TextField, Button } from "@mui/material";
import axios from "axios";
import { baseUrl } from "../../constants/url.constant";

const DeleteProduct = () => {
  const redirect = useNavigate();
  const { id } = useParams();

  const handleDeleteBtnClick = () => {
    axios
      .delete(`${baseUrl}/${id}`)
      .then((resposne) =>
        redirect("/products", {
          state: { message: "Product Deleted Successfully" },
        })
      )
      .catch((error) => alert("Error"));
  };

  const handleBackBtnClick = () => {
    redirect("/products");
  };

  return (
    <div className="edit-product">
      <h2>Delete Product</h2>
      <h4>Are Sure You Want To Delete Id : {id} Product?</h4>

      <div>
        <Button variant="outlined" color="error" onClick={handleDeleteBtnClick}>
          Yes, Delete It
        </Button>
        <Button variant="outlined" color="info" onClick={handleBackBtnClick}>
          No, Not Delete It & Back
        </Button>
      </div>
    </div>
  );
};

export default DeleteProduct;
