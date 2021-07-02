import {
  AuthContainer,
  LeftBoxContainer,
  RightBoxContainer,
  LeftBottomContainer,
  FingerPrintIllulstration,
  AuthLeftText,
} from "./WithAuthContainer.styles";

import LogoBrand from "../../UIs/LogoBrand/logobrand.ui";

import fingerPrint from "../../../assets/images/fingerpringt-illustration.svg";

const WithAuthContainer =
  (WrapperComponent) =>
  ({ ...props }) => {
    return (
      <AuthContainer>
        <LeftBoxContainer>
          <LogoBrand className="text-orange" />
          <LeftBottomContainer>
            <FingerPrintIllulstration
              src={fingerPrint}
              title={"fingerprint"}
              className="img-fluid"
            />
            <AuthLeftText>
              Welcome to <span className="text-orange">Bilbayt HomeWork</span>
            </AuthLeftText>
          </LeftBottomContainer>
        </LeftBoxContainer>
        <RightBoxContainer>
          <WrapperComponent {...props} />
        </RightBoxContainer>
      </AuthContainer>
    );
  };
export default WithAuthContainer;
