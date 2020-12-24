<template>
    <v-container fluid>
             <v-row column align-center>        
            <v-col cols="9">
                <h1>Positions {{ positions.length }}</h1>
            </v-col>
            <v-col cols="3">
                <AddPosition @positionInfo="getNewPositionData($event)"></AddPosition>
            </v-col>
        </v-row>
        <v-row>
            <StockPositions :items="positions" />
        </v-row>
</v-container>
</template>

<script lang="ts">
    import { Component, Vue } from 'vue-property-decorator';
    import StockPositions from '@/components/StockPositions.vue'; // @ is an alias to /src    
    import AddPosition from '@/components/AddPosition.vue'; // @ is an alias to /src    
       

    @Component({
        components: {
            StockPositions, 
            AddPosition
        },
    })
    export default class Positions extends Vue {

        public addedPosition: Object = {}

        public positions: Object[] = [];

        async mounted() {
            console.log("mounted");
            if (this.$store.getters['positions/positionCount'] == 0) {
                this.fetchData();
                this.positions = this.$store.getters['positions/getAll'];
            }
        }

        public fetchData(): void {
            this.$store.dispatch("positions/loadStockPositions");
        }

        public getNewPositionData(value: Object): void {
            console.log(value);

            this.$store.dispatch("positions/addPosition", value);

            //TODO: Call action for new position creation and then use promise to make API call to get latest and refresh.
        }
    }

</script>
