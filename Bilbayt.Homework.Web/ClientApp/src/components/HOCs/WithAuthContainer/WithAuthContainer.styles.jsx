import styled, { css } from "styled-components";

export const AuthContainer = styled.div`
  display: flex;
  @media scren and (max-width 767px) {
    flex-direction: column;
  }
`;

const ContentCss = css`
  width: 50%;
  min-height: 100vh;
  display: flex;
  flex-direction: column;
  justify-content: center;

  @media screen and (max-width: 767px) {
    width: 100%;
    min-height: unset;
  }
`;

export const FingerPrintIllulstration = styled.img`
  @media screen and (max-width 767px) {
    .fingerprint-illustration {
      display: none;
    }
  }
`;

export const LeftBoxContainer = styled.div`
  ${ContentCss}

  background-color: #000;
  padding: 15px 20px 25px 25px;
  justify-content: space-between;
  align-items: center;

  @media screen and (max-width: 702px) {
    padding-bottom: 30px;
  }
`;

export const LeftBottomContainer = styled.div``;

export const RightBoxContainer = styled.div`
  ${ContentCss}
  background-color: #f8f8f8;
  padding: 25px 50px;

  @media screen and (max-width: 767px) {
    min-height: calc(100vh - 220px);
    align-items: center;
    padding: 25px;
  }
`;

export const AuthLeftText = styled.p`
  margin-top: 65px;
  font-weight: bold;
  font-size: 26px;
  line-height: 44px;
  color: #ffffff;
  text-shadow: 0px 4px 4px rgba(0, 0, 0, 0.25);
`;
