import { FormContainer } from "./profile.style";
import FormInput from "../../UIs/FormInput/FormInput.ui";

const ProfileForm = () => {
  return (
    <FormContainer>
      <div className="form-row">
        <div className="col-md-6 col-lg-6 col-sm-12">
          <FormInput placeholder="UserName" className="form-control" />
        </div>
        <div className="col-md-6 col-lg-6 col-sm-12">
          <FormInput placeholder="FullName" className="form-control" />
        </div>
      </div>
    </FormContainer>
  );
};

export default ProfileForm;
