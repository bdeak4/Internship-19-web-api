import React from "react";
import { useParams } from "react-router-dom";
import AdList from "src/components/List/AdList";

const Category = () => {
  const { id } = useParams();

  return (
    <div>
      <h1>Category</h1>
      <AdList defaultFilter={{ categoryId: id }} />
    </div>
  );
};

export default Category;
