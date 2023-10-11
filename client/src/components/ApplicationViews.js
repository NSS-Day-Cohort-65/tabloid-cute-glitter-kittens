import { Route, Routes } from "react-router-dom";
import { AuthorizedRoute } from "./auth/AuthorizedRoute";
import Login from "./auth/Login";
import Register from "./auth/Register";
import UserProfileList from "./userprofiles/UserProfilesList";
import UserProfileDetails from "./userprofiles/UserProfileDetails";
import PostsList from "./posts/PostsList";
import TagsList from "./tags/TagsList";
import { CategoriesList } from './categories/CategoriesList';
import CreateCategory from "./categories/CreateCategory";
import CreateReaction from "./reactions/ReactionForm";
import ReactionsList from "./reactions/ReactionList";
import CommentsList from "./comments/CommentsList";
import CreatePost from './posts/CreatePost';
import CreatePost from './posts/CreatePost';
import { CreateTag } from "./tags/CreateTag.js";

export default function ApplicationViews({ loggedInUser, setLoggedInUser }) {
  return (
    <Routes>
      <Route path="/">
        <Route
          index
          element={
            <AuthorizedRoute loggedInUser={loggedInUser}>
              <p>Welcome to Tabloid!</p>
            </AuthorizedRoute>
          }
        />
        <Route path="/posts">
          <Route
            index
            element={
              <AuthorizedRoute loggedInUser={loggedInUser}>
                <PostsList />
              </AuthorizedRoute>
            }>
              <Route 
                path=":postId/comments"
                element={
                  <AuthorizedRoute loggedInUser={loggedInUser}>
                    <CommentsList />
                  </AuthorizedRoute>
                } />
          </Route>
          <Route
            path='create'
            element={
              <AuthorizedRoute loggedInUser={loggedInUser}>
                <CreatePost loggedInUser={loggedInUser} />
              </AuthorizedRoute>
            }
          />
        </Route>
        <Route path="/userprofiles">
          <Route
            index
            element={
              <AuthorizedRoute loggedInUser={loggedInUser} roles={["Admin"]}>
                <UserProfileList />
              </AuthorizedRoute>
            }
          />
          <Route
            path=":id"
            element={
              <AuthorizedRoute loggedInUser={loggedInUser} roles={["Admin"]}>
                <UserProfileDetails />
              </AuthorizedRoute>
            }
          />
        </Route>
        <Route path="/tags">
          <Route
            index
            element={
              <AuthorizedRoute loggedInUser={loggedInUser}>
                <TagsList />
              </AuthorizedRoute>
            } />
        <Route path='create'
          element={
            <AuthorizedRoute loggedInUser={loggedInUser} >
              <CreateTag />
            </AuthorizedRoute>
          }
          />
        </Route>
        <Route path='/categories'>
          <Route
            index
            element={
              <AuthorizedRoute loggedInUser={loggedInUser} roles={["Admin"]}>
                <CategoriesList />
              </AuthorizedRoute>
            }
          />
          <Route path='create'
            element={
              <AuthorizedRoute loggedInUser={loggedInUser} roles={["Admin"]}>
                <CreateCategory />
              </AuthorizedRoute>
            }
          />
        </Route>
        <Route path="/reactions">
          <Route
            index
            element={
              <AuthorizedRoute loggedInUser={loggedInUser}>
                <ReactionsList />
              </AuthorizedRoute>
            }
          />
          <Route path="create"
            element={
              <AuthorizedRoute loggedInUser={loggedInUser} roles={["Admin"]}>
                <CreateReaction />
              </AuthorizedRoute>
            } />
        </Route>
        <Route
          path="login"
          element={<Login setLoggedInUser={setLoggedInUser} />}
        />
        <Route
          path="register"
          element={<Register setLoggedInUser={setLoggedInUser} />}
        />
      </Route>
      <Route path="*" element={<p>Whoops, nothing here...</p>} />
    </Routes>
  );
}
