module TableTests

open Expecto
open ReactNode
open Fable.Helpers.React.Props
module R = Fable.Helpers.React

[<Tests>]
let tests =
    testList "Table tests" [

        test "Table should be a react html node" {
            let node = R.Node ("table", [ClassName "table"], [])
            let subject = Table.table [] [] []
            compareNode subject node
        }

        test "Table props should map to classes" {
            let tableProps = [Table.Kind Table.Striped]
            let subject = List.map Table.classes tableProps
            Expect.contains subject "table-striped" "Should contain striped class"
        }

        test "Head should be a react html node" {
            let node = R.Node ("thead", [], [])
            let subject = Table.thead [] []
            compareNode subject node
        }
        
        test "Body should be a react html node" {
            let node = R.Node ("tbody", [], [])
            let subject = Table.tbody [] []
            compareNode subject node
        }

        test "Row props should map to classes" {
            let rowProps = [Table.Row.Kind Table.Row.Active]
            let subject = List.map Table.Row.classes rowProps
            Expect.contains subject "active" "Should contain active class"
        }

        test "Row should be a react html node" {
            let node = R.Node ("tr", [ClassName ""], [])
            let subject = Table.tr [] [] []
            compareNode subject node
        }

        test "Cell should be a react html node" {
            let node = R.Node ("td", [], [])
            let subject = Table.td [] []
            compareNode subject node
        }

        test "Header cell should be a react html node" {
            let node = R.Node ("th", [], [])
            let subject = Table.th [] []
            compareNode subject node
        }
    ]