import { useContext } from "react";
import { useGetAdOwnerDetail, usePutAdOwner } from "src/api/useAdOwner";
import AdOwnerForm from "src/components/Forms/AdOwnerForm";
import AdList from "src/components/List/AdList";
import Loader from "src/components/Loader";
import { UserContext } from "src/providers/UserProvider";

const Profile = () => {
  const {
    state: { id },
  } = useContext(UserContext);
  const {
    data: adOwnerDetail,
    error: adOwnerDetailError,
    isLoading: adOwnerDetailIsLoading,
  } = useGetAdOwnerDetail(id);
  const putAdOwner = usePutAdOwner(id);

  if (adOwnerDetailIsLoading) {
    return <Loader />;
  }

  if (adOwnerDetailError) {
    return <span className="error">Issue getting ad details</span>;
  }

  return (
    <div>
      <h1>Profile</h1>
      <AdOwnerForm {...adOwnerDetail} {...putAdOwner} />
      <h1>User Ads</h1>
      <AdList defaultFilter={{ ownerId: id }} />
    </div>
  );
};

export default Profile;
