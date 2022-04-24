import React from "react";
import { useGetAdCategories } from "src/api/useAdCategory";
import Action from "src/components/Action";
import List from "src/components/List";
import Loader from "src/components/Loader";

import styles from "./categories.module.scss";

const Categories = () => {
  const columns = ["Title", "Type", "Ad Count"];
  const { data, isLoading, error } = useGetAdCategories();

  if (isLoading) {
    return <Loader />;
  }

  const rows = data
    ? data.map((data) => [
        <Action
          variant="inverted"
          renderAs="Link"
          props={{ to: `/categories/${data.id}` }}
        >
          {data.title}
        </Action>,
        <span>{data.type}</span>,
        <span>{data.adCount}</span>,
      ])
    : [];

  return (
    <div className={styles.wrapper}>
      <div className={styles.heading}>
        <h1>Categories</h1>
      </div>
      <List columns={columns} rows={rows} error={error} />
    </div>
  );
};

export default Categories;
