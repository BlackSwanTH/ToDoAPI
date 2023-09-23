import { Routes, Route } from "react-router-dom";
import SignIn from "./pages/SignIn";
import Main from "./pages/Main";
import Credit from "./pages/Credit";
import SignOut from "./pages/SignOut";
function App() {
  return (
    <Routes>
      <Route path="/" element={<SignIn />} />
      <Route path="/main" element={<Main />} />
      <Route path="/credit" element={<Credit />} />
      <Route path="/signout" element={<SignOut />} />
    </Routes>
  );
}

export default App;
