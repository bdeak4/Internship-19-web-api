import React from "react";
import { useParams } from "react-router-dom";
import { useGetAdDetail, usePutAd } from "src/api/useAd";
import AdForm from "src/components/Forms/AdForm";
import Loader from "src/components/Loader";

import styles from "./edit-ad.module.scss";

const EditAd = () => {
  const { id } = useParams();
  const {
    data: adDetail,
    error: adDetailError,
    isLoading: adDetailIsLoading,
  } = useGetAdDetail(id);
  const putAd = usePutAd(id);

  if (adDetailIsLoading) {
    return <Loader />;
  }

  if (adDetailError) {
    return <span className="error">Issue getting ad details</span>;
  }

  return (
    <div className={styles.wrapper}>
      <h1 className={styles.heading}>Edit ad</h1>
      <AdForm {...adDetail} {...putAd} />
    </div>
  );
};

export default EditAd;
