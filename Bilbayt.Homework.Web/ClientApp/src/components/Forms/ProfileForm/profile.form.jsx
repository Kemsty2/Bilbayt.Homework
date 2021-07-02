import { FormContainer } from "./profile.style";
import FormInput from "../../UIs/FormInput/FormInput.ui";

const ProfileForm = ({ profile }) => {
  return (
    <FormContainer>
      <div className="form-row">
        <div className="col-md-6 col-lg-6 col-sm-12">
          <FormInput
            placeholder="UserName"
            className="form-control"
            readOnly
            value={profile.userName}
          />
        </div>
        <div className="col-md-6 col-lg-6 col-sm-12">
          <FormInput
            placeholder="FullName"
            className="form-control"
            readOnly
            value={profile.fullName}
          />
        </div>
      </div>
    </FormContainer>
  );
};

export default ProfileForm;
