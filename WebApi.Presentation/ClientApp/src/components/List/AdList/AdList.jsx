import React, { useEffect, useContext, useState } from "react";
import { useDeleteAd, useGetAds } from "src/api/useAd";
import Action from "src/components/Action";

import List from "src/components/List";
import Loader from "src/components/Loader";
import { UserContext } from "src/providers/UserProvider";
import Filter from "../Filter";

const AdList = ({ defaultFilter = {} }) => {
  const [filter, setFilter] = useState(defaultFilter);
  const columns = ["Title", "Price", "Description", "Actions"];
  const { data, error, isLoading, triggerReload } = useGetAds(filter);
  const {
    handleRequest: handleDelete,
    error: deleteError,
    isLoading: isDeleteLoading,
    isSuccessful: isDeleteSuccessful,
  } = useDeleteAd();
  const {
    state: { id: userId },
  } = useContext(UserContext);

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
        data.ownerId === userId && (
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
          </div>
        ),
      ])
    : [];

  return (
    <div>
      <Filter filter={filter} setFilter={setFilter} />
      {deleteError && <span className="error">{deleteError}</span>}
      {isLoaderVisible && <Loader />}
      {!isLoaderVisible && <List columns={columns} rows={rows} error={error} />}
    </div>
  );
};

export default AdList;
