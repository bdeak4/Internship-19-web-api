import React from "react";
import { useParams } from "react-router-dom";
import { useGetAdDetail } from "src/api/useAd";
import Action from "src/components/Action";
import Loader from "src/components/Loader";

import styles from "./ad.module.scss";

const Ad = () => {
  const { id } = useParams();
  const {
    data: adDetail,
    error: adDetailError,
    isLoading: adDetailIsLoading,
  } = useGetAdDetail(id);

  if (adDetailIsLoading || !adDetail) {
    return <Loader />;
  }

  if (adDetailError) {
    return <span className="error">Issue getting ad details</span>;
  }

  return (
    <div className={styles.wrapper}>
      <h1 className={styles.heading}>{adDetail.title}</h1>
      <p>
        <b>Price:</b> {adDetail.price}
      </p>
      <p>
        <b>Description:</b> {adDetail.description}
      </p>
      <p>
        <b>Category:</b> {adDetail.category?.title}
      </p>
      <p>
        <b>Owner:</b> {adDetail.owner?.email}
      </p>
      <p>
        <b>City:</b> {adDetail.city}
      </p>
      <p>
        <b>County:</b> {adDetail.county}
      </p>
      <p>
        <b>Street:</b> {adDetail.street}
      </p>
      <p>
        <b>View Counter:</b> {adDetail.viewCounter}
      </p>
      <Action renderAs="Link" props={{ to: "/ads" }}>
        &larr; Ads
      </Action>
    </div>
  );
};

export default Ad;
