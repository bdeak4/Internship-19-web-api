import React from "react";

import AdForm from "src/components/Forms/AdForm";

import { useAddAd } from "src/api/useAd";

import styles from "./add-ad.module.scss";

const AddAd = () => {
  const formProps = useAddAd();

  return (
    <div className={styles.wrapper}>
      <h1 className={styles.heading}>Add Ad</h1>
      <AdForm {...formProps} />
    </div>
  );
};

export default AddAd;
