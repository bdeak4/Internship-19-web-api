import React, { useEffect } from "react";
import { useDeleteAd, useGetAds } from "src/api/useAd";
import Action from "src/components/Action";

import List from "src/components/List";
import Loader from "src/components/Loader";

import styles from "./ads.module.scss";

const Ads = () => {
  const columns = ["Title", "Price", "Description", "Actions"];
  const { data, error, isLoading, triggerReload } = useGetAds();
  const {
    handleRequest: handleDelete,
    error: deleteError,
    isLoading: isDeleteLoading,
    isSuccessful: isDeleteSuccessful,
  } = useDeleteAd();

  useEffect(() => {
    if (isDeleteSuccessful) {
      triggerReload();
    }
  }, [isDeleteSuccessful, triggerReload]);

  const isLoaderVisible = isLoading || isDeleteLoading;

  const rows = data
    ? data.map((data) => [
        <Action
          variant="inverted"
          renderAs="Link"
          props={{ to: `/ads/${data.id}` }}
        >
          {data.title}
        </Action>,
        <span>{data.price} kn</span>,
        <span>{data.description}</span>,
        <div>
          <Action
            variant="inverted"
            renderAs="Link"
            props={{ to: `/ads/${data.id}/edit` }}
          >
            Edit
          </Action>{" "}
          <Action
            variant="danger"
            props={{
              onClick: () => {
                handleDelete(null, `/${data.id}`);
              },
            }}
          >
            Delete
          </Action>
        </div>,
      ])
    : [];

  return (
    <div className={styles.wrapper}>
      <div className={styles.heading}>
        <h1>Ads</h1>
        <Action variant="fill" renderAs="Link" props={{ to: "/ads/add" }}>
          Add Ad
        </Action>
      </div>
      <div>
        {deleteError && <span className="error">{deleteError}</span>}
        {isLoaderVisible && <Loader />}
        {!isLoaderVisible && (
          <List columns={columns} rows={rows} error={error} />
        )}
      </div>
    </div>
  );
};

export default Ads;
